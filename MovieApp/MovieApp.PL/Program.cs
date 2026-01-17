using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DAL.Data;

namespace MovieApp.PL;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        // var serviceCollection = new ServiceCollection();
        // serviceCollection.AddDbContext<MovieAppDbContext>(options =>
        // {
        //   options.UseSqlServer("Server=localhost,1433;Database=MovieAppDb;User Id=sa;Password=CodeWithArjun123;TrustServerCertificate=True;");
        // });
        // var serviceProvider = serviceCollection.BuildServiceProvider();
        // using var context =serviceProvider.GetRequiredService<MovieAppDbContext>();
    }
}