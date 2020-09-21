using Domain.Core.Entities;
using Domain.Interfaces.Base;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entity_Framework.Repository;
using Services.Data.AutoMapper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    class MatchupService : IMatchupService
    {
        private readonly IRepositoryAsync<Matchup> _matchupRepositoryAsync;
        private readonly IAutoMapper _mapper;

        public MatchupService(IRepositoryAsync<Matchup> repositoryAsync)
        {
            _matchupRepositoryAsync = repositoryAsync;
            _mapper = new AutoMapper.AutoMapper();
        }

        public async Task<IEnumerable<Matchup>> GetMatchupsAsync(int id)
        {
            
        }
    }
}
