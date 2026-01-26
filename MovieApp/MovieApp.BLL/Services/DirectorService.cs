using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.BLL.Dtos.DirectorDtos;
using MovieApp.BLL.Profiles;
using MovieApp.DAL.Data;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Services;

public class DirectorService(
    MovieAppDbContext context,
    IMapper mapper
    )
{
    // private readonly MovieAppDbContext _movieAppDbContext;
    //
    // public DirectorService(MovieAppDbContext movieAppDbContext)
    // {
    //     movieAppDbContext = movieAppDbContext;
    // }
    public List<DirectorReturnDto> GetAllDirectors()
    {
        var directors = context.Directors.ToList();
        List<DirectorReturnDto> directorReturnDtos = new List<DirectorReturnDto>();
        foreach (var director in directors)
        {
            var directorReturnDto = new DirectorReturnDto()
            {
                Name = director.Name,
                Description = director.Description,
                Adress = director.Adress,
                City = director.City,
                Age = director.Age,
                Region = director.Region
            };
            directorReturnDtos.Add(directorReturnDto);
        }
        return directorReturnDtos;
    }

    public async Task<List<DirectorReturnDto>> GetAllDirectorsAsync()
    {
        var directors= await context.Directors.ToListAsync();
        var directorReturnDtos = mapper.Map<List<DirectorReturnDto>>(directors);
        return directorReturnDtos;
    }
      

    public DirectorReturnDto GetDirectorbyId(int id)
    {
        var existingDirector = context.Directors.FirstOrDefault(d => d.Id == id);
        if(existingDirector == null)
            throw new Exception("Director not found");
        var directorReturnDto = mapper.Map<DirectorReturnDto>(existingDirector);
        return directorReturnDto;
    }

    public async Task<DirectorReturnDto> GetDirectorByIdAsync(int id)
    {
        var extistingDirector = await context.Directors.FirstOrDefaultAsync(d => d.Id == id);
        if(extistingDirector == null)
            throw new Exception("Director not found");
        var directorReturnDto = mapper.Map<DirectorReturnDto>(extistingDirector);
        return directorReturnDto;
    }

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
        var director = DirectorMapper.ToDirector(directorCreateDto);
        context.Directors.Add(director);
        context.SaveChanges();
    }
    
    public async Task AddDirectorAsync(DirectorCreateDto directorCreateDto)
    {
        if( await context.Directors.AnyAsync(d=>d.Name.Equals(directorCreateDto.Name)))
            throw new Exception("Director already exists");
        var director = DirectorMapper.ToDirector(directorCreateDto);
        await context.Directors.AddAsync(director);
         await context.SaveChangesAsync();
    }
   
}