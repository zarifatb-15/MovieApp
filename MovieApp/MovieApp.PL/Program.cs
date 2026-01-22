using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.BLL.Services;
using MovieApp.DAL.Data;

namespace MovieApp.PL;

class Program
{
    static void  Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var serviceCollection = new ServiceCollection();
       serviceCollection.AddScoped<DirectorService>();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        using var context =serviceProvider.GetRequiredService<MovieAppDbContext>();
        
    }
}