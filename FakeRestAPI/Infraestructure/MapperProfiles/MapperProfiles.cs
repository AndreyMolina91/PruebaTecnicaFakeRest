using AutoMapper;
using FakeRestAPI.Domain.Models;
using FakeRestAPI.Infraestructure.Dto;
using FakeRestAPI.Models;

namespace FakeRestAPI.Infraestructure.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<UsersDto, UsersModel>().ReverseMap();
            CreateMap<ActivitiesDto, ActivitiesModel>().ReverseMap();
            CreateMap<BooksDto, BooksModel>().ReverseMap();
            CreateMap<AuthorsDto, AuthorsModel>().ReverseMap();
        }
    }
}
