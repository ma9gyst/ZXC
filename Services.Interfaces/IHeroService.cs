using Domain.Core.Entities;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entity_Framework;
using Infrastructure.Data.Entity_Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IHeroService
    {
        public Task InitializeTableHeroAsync();
        public Task<IEnumerable<HeroDto>> GetAllAsync();
        public Task<Hero> GetHeroAsync(int id);
    }
}
