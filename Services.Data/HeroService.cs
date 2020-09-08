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
        private readonly IRepositoryAsync<Hero> _repositoryAsync;
        private readonly IAutoMapper _mapper;
        public HeroService(IRepositoryAsync<Hero> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = new AutoMapper.AutoMapper();
        }
        public async Task<IEnumerable<HeroDto>> GetAllAsync()
        {
            return _mapper.Mapper.Map<List<HeroDto>>(await _repositoryAsync.ReadAllAsync());
        }

        public async Task WriteAllAsync(IEnumerable<HeroDto> heroesDto)
        {
            foreach (var hero in _mapper.Mapper.Map<List<Hero>>(heroesDto))
                await _repositoryAsync.CreateAsync(hero);
        }
    }
}
