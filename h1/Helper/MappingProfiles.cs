using AutoMapper;
using h1.Dto;
using h1.Models;

namespace h1.Helper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}