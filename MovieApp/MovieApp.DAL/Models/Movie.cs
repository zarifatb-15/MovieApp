namespace MovieApp.DAL.Models;

public class Movie: BaseEntity
{
    public string? Title { get; set; }= null!;
    
    public DateTime ReleaseYear { get; set; }
    
    public string? Description { get; set; }= null!;
    
    
    
}