using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entity_Framework.Repository
{
    public class MatchupRepositoryAsync : AbstractBaseRepository<Matchup>
    {
        public MatchupRepositoryAsync(DatabaseContext databaseContext) : base(databaseContext) { }

        public override DbSet<Matchup> GetTable()
        {
            return _databaseContext.Matchups;
        }

        public async override Task<Matchup> ReadAsync(int id)
        {
            return await _databaseContext.Matchups.FirstOrDefaultAsync(C => C.Id == id);
        }

        public async Task CreateRangeAsync(List<Matchup> matchups)
        {
            await _databaseContext.AddRangeAsync(matchups);
            await _databaseContext.SaveChangesAsync();
        }
        public override async Task<IQueryable<Matchup>> ReadAllAsync()
        {
            return _databaseContext.Matchups.Include(c => c.Enemy).Include(c => c.Hero).AsNoTracking();
        }
    }
}
