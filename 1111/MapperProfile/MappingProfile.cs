using _1111.Models;
using AutoMapper;
using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1111.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HeroDto, HeroViewModel>();
            CreateMap<HeroViewModel, HeroDto>();
        }
    }
}
