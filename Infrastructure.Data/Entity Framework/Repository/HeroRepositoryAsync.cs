using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entity_Framework.Repository
{
    public class HeroRepositoryAsync : AbstractBaseRepository<Hero>
    {
        public HeroRepositoryAsync(DatabaseContext databaseContext) : base(databaseContext) { }

        public override DbSet<Hero> GetTable()
        {
            return _databaseContext.Heroes;
        }

        public async override Task<Hero> ReadAsync(int id)
        {
            return await _databaseContext.Heroes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task WriteAll(List<Hero> heroes) 
        {
            await _databaseContext.AddRangeAsync(heroes);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            _databaseContext.Heroes.RemoveRange(_databaseContext.Heroes);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
