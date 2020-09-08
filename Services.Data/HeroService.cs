using Domain.Core.Entities;
using Domain.Interfaces.Base;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entity_Framework.Repository;
using Services.Data.AutoMapper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class HeroService : IHeroService
    {
        private IRepositoryAsync<Hero> repos;
        readonly IAutoMapper mapper;
        public HeroService(IRepositoryAsync<Hero> repos)
        {
            this.repos = repos;
            mapper = new AutoMapper.AutoMapper();
        }
        public async Task<IEnumerable<HeroDto>> GetAll()
        {
            return mapper.Mapper.Map<List<HeroDto>>(await repos.ReadAllAsync());
        }
    }
}
