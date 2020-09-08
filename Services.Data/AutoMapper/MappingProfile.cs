using AutoMapper;
using Domain.Core.Entities;
using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hero, HeroDto>();
            CreateMap<HeroDto, Hero>();
        }
    }
}
