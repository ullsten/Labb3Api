using Labb3ApiRoutes.Models;
using AutoMapper;
using Labb3ApiRoutes.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Labb3ApiRoutes.Models.DTO.PersonEverythingDTO;

namespace Labb3ApiRoutes
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person, PersonCreateDTO>().ReverseMap();
            CreateMap<Person, PersonUpdateDTO>().ReverseMap();
            CreateMap<Person, PersonEverythingDTO>().ReverseMap();

            CreateMap<Interest, InterestDTO>().ReverseMap();
            CreateMap<Interest, InterestCreateDTO>().ReverseMap();
            CreateMap<Interest, PersonEverythingDTO>().ReverseMap();


            CreateMap<Link, LinkDTO>().ReverseMap();
            CreateMap<Link, LinkCreateDTO>().ReverseMap();
            CreateMap<Link, LinkUpdateDTO>().ReverseMap();
        }
    }
}
