using Domain.Core.Entities;
using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMatchupService
    {
        public Task<IEnumerable<Matchup>> GetMatchupsAsync(int heroId);
        public Task<IEnumerable<Matchup>> EfficientVersusAsync(int heroId);
        public Task<IEnumerable<Matchup>> InefficientVersusAsync(int heroId);
    }
}
