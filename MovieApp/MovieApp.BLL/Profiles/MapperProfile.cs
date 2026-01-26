using AutoMapper;
using MovieApp.BLL.Dtos.DirectorDtos;
using MovieApp.DAL.Models;

namespace MovieApp.BLL.Profiles;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Director, DirectorReturnDto>();
        CreateMap<DirectorCreateDto, Director>();
    }
}