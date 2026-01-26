namespace MovieApp.BLL.Dtos.DirectorDtos;

public class DirectorReturnDto
{
    public string Name { get; set; }=null!;
    
    public string Description { get; set; }=null!;
    
    public string Adress { get; set; }=null!;
    
    public string? City { get; set; }
    
    public int Age { get; set; }
    
    public string? Region { get; set; }
}