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
       await context.Directors.ToList();

}