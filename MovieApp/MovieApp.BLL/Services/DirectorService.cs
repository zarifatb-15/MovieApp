using Microsoft.EntityFrameworkCore;
using MovieApp.BLL.Dtos.DirectorDtos;
using MovieApp.DAL.Data;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Services;

public class DirectorService(MovieAppDbContext context)
{
    // private readonly MovieAppDbContext _movieAppDbContext;
    //
    // public DirectorService(MovieAppDbContext movieAppDbContext)
    // {
    //     movieAppDbContext = movieAppDbContext;
    // }
    public List<Director> GetAllDirectors() => 
        context.Directors.ToList();
    public async Task<List<Director>>GetAllDirectorsAsync()=>
       await context.Directors.ToListAsync();

    public Director? GetDirectorbyId(int id) =>
        context.Directors.FirstOrDefault(d => d.Id == id);

    public async Task<Director?> GetDirectorByIdAsync(int id) =>
        await context.Directors.FirstOrDefaultAsync(d => d.Id == id);

    public List<Director> GetAllDirectorsSearch(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception();
        return context.Directors
            .Where(d=>d.Name.Contains(value))
            .ToList();
    }
    
    public async Task <List<Director>> GetAllDirectorsSearchAsync(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new Exception();
        return await context.Directors
            .Where(d=>d.Name.Contains(value))
            .ToListAsync();
        
    }

    public void AddDirector(DirectorCreateDto directorCreateDto)
    {
        if(context.Directors.Any(d=>d.Name.Equals(directorCreateDto.Name)))
            throw new Exception("Director already exists");
        var director = new Director
        {
            Name = directorCreateDto.Name,
            Description = directorCreateDto.Description,
            Adress = directorCreateDto.Adress,
            City = directorCreateDto.City,
            Age = directorCreateDto.Age,
            Region = directorCreateDto.Region
        };
        context.Directors.Add(director);
        context.SaveChanges();
    }
    
    public async Task AddDirectorAsync(Director director)
    {
        if( await context.Directors.AnyAsync(d=>d.Name.Equals(director.Name, StringComparison.OrdinalIgnoreCase)))
            throw new Exception("Director already exists");
        await context.Directors.AddAsync(director);
         await context.SaveChangesAsync();
    }
   
}