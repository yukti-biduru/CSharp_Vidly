using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            
            Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}