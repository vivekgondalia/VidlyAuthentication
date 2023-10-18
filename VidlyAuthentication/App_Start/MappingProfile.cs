using AutoMapper;
using VidlyAuthentication.Models;
using VidlyAuthentication.Dtos;

namespace VidlyAuthentication.App_Start
{
    public class MappingProfile : Profile
    {
        //Automapper - A Convention Based Mappingn Tool. Uses property name.
        public MappingProfile()
        {
            //Domain Model to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //Dto to Domain Model
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
               .ForMember(m => m.Id, opt => opt.Ignore());
           ;
        }
    }
}