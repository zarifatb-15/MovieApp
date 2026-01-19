using Microsoft.EntityFrameworkCore;
using MovieApp.DAL.Models;

namespace MovieApp.DAL.Data;

public class MovieAppDbContext: DbContext
{
     public DbSet<Director> Directors { get; set; }
    
     // public MovieAppDbContext(DbContextOptions <MovieAppDbContext> options) : base(options)
     // {
     //
     // }
     //
     
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MovieAppDb;User Id=sa;Password=CodeWithArjun123;TrustServerCertificate=True;");
         base.OnConfiguring(optionsBuilder);
     }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieAppDbContext).Assembly);
          //modelBuilder.ApplyConfiguration(new Configurations.DirectorConfiguration());
          base.OnModelCreating(modelBuilder);
     }
}