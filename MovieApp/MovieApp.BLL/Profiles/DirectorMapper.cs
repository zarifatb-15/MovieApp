using MovieApp.BLL.Dtos.DirectorDtos;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Profiles;

public class DirectorMapper
{
    public static DirectorReturnDto ToDirectorReturnDto(Director director)=>
         new DirectorReturnDto
        {
            Name = director.Name,
            Description = director.Description,
            Adress = director.Adress,
            City = director.City,
            Age = director.Age,
            Region = director.Region
        };
    public static Director ToDirector(DirectorCreateDto directorCreateDto)=>
        new Director
        {
            Name = directorCreateDto.Name,
            Description = directorCreateDto.Description,
            Adress = directorCreateDto.Adress,
            City = directorCreateDto.City,
            Age = directorCreateDto.Age,
            Region = directorCreateDto.Region
        };
}

