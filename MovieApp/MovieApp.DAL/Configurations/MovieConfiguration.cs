using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.DAL.Models;

namespace MovieApp.DAL.Configurations;

public class MovieConfiguration: IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m=>m.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.ReleaseYear)
            .IsRequired();

        builder.Property(m=>m.Duration)
            .IsRequired();
        
        builder.Property(m=>m.Imdb)
            .IsRequired()
            .HasColumnType("decimal (18,2)");
        
        builder.HasOne(m => m.Director)
            .WithMany(d=>d.Movies)
            .HasForeignKey(m => m.DirectorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Seed Data
        builder.HasData(
            new Movie
            {
             Id = 1,
             Title = "Inception",
             Description = "A mind-bending thriller about dream invasion.",
             ReleaseYear = new DateTime(2010, 7, 16),
             Duration = 148,
             Imdb = 8.8m,
             DirectorId = 1      
            },
            new Movie
            {
             Id = 2,
             Title = "The Dark Knight",
             Description = "Batman faces the Joker in Gotham City.",
             ReleaseYear = new DateTime(2008, 7, 18),
             Duration = 152,
             Imdb = 9.0m,
             DirectorId = 1      
            },
            new Movie
            { Id = 3,
             Title = "Pulp Fiction",
             Description = "Interwoven stories of crime in Los Angeles.",
             ReleaseYear = new DateTime(1994, 10, 14),
             Duration = 154,
             Imdb = 8.9m,
             DirectorId = 2      
            },
            new Movie
            {
             Id = 4,
             Title = "Kill Bill: Vol. 1",
             Description = "A bride seeks revenge on her former lover.",
             ReleaseYear = new DateTime(2003, 10, 10),
             Duration = 111,
             Imdb = 8.1m,
             DirectorId = 2      
            },
            new Movie
            {
             Id = 5,
             Title = "Forrest Gump",
             Description = "The life journey of a simple man with a big heart.",
             ReleaseYear = new DateTime(1994, 7, 6),
             Duration = 142,
             Imdb = 8.8m,
             DirectorId = 3      
            },
            new Movie
            {
             Id = 6,
             Title = "Saving Private Ryan",     
             Description = "A WWII mission to save a paratrooper behind enemy lines.",
             ReleaseYear = new DateTime(1998, 7, 24),
             Duration = 169,
             Imdb = 8.6m,
             DirectorId = 4      
            }
        );

    }

    
}