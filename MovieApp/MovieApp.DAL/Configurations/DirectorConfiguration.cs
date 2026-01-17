using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.DAL.Models;

namespace MovieApp.DAL.Configurations;

public class DirectorConfiguration:IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Director");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(d => d.Adress)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.City)
            .IsRequired(false);
            
            builder.Property(d => d.Age)
                .IsRequired();

            // Seed Data
            builder.HasData
            (
                new Director
                {
                    Id = 1,
                    Name = "Steven Spielberg",
                    Description =
                        "An American filmmaker known for his work in the adventure and science fiction genres.",
                    Adress = "123 Hollywood Blvd, Los Angeles, CA",
                    City = "Los Angeles",
                    Age = 77
                },
                new Director
                    {
                        Id = 2,
                        Name = "Christopher Nolan",
                        Description =
                            "A British-American filmmaker known for his complex narratives and innovative storytelling techniques.",
                        Adress = "456 Sunset St, Burbank, CA",
                        City = "Burbank",
                        Age = 50
                    },
                new Director
                    {
                        Id = 3,
                        Name = "Quentin Tarantino",
                        Description =
                            "An American filmmaker known for his stylized violence, sharp dialogue, and non-linear storytelling.",
                        Adress = "789 Vine St, Los Angeles, CA",
                        City = "Los Angeles",
                        Age = 58
                    },
                new Director
                    {
                        Id = 4,
                        Name = "Martin Scorsese",
                        Description =
                            "An American filmmaker known for his work in the crime and drama genres, often exploring themes of guilt and redemption.",
                        Adress = "321 Hollywood Blvd, New York, NY",
                        City = "New York",
                        Age = 78
                    }
                
            );



    }
}