using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.BLL.Dtos.DirectorDtos;
using MovieApp.BLL.Services;
using MovieApp.DAL.Data;
using MovieApp.DAL.Models;

namespace MovieApp.PL;

class Program
{
    static void  Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<MovieAppDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost,1433;Database=MovieAppDb;User Id=sa;Password=CodeWithArjun123;TrustServerCertificate=True;");
        });
       serviceCollection.AddScoped<DirectorService>();
        var serviceProvider = serviceCollection.BuildServiceProvider(); 
        var directorService= serviceProvider.GetRequiredService<DirectorService>();
        // var directors = directorService.GetAllDirectors();
        // foreach (var director in directors)
        // {
        //     Console.WriteLine($"Director Id: {director.Id}, Name: {director.Name}");
        // }
        // var directors = directorService.GetAllDirectorsSearch("a");
        // foreach (var item in directors)
        //     Console.WriteLine(item.Name);
        var newDirector = new DirectorCreateDto
        {
            Name = "director x",
            Description = "British-American film director, producer, and screenwriter.",
            Adress = "Los Angeles, CA",
            City = "Los Angeles",
            Age = 50,
            Region = "California"
        };
        directorService.AddDirector(newDirector);
    }
}