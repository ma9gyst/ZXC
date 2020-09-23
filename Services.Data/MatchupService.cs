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
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Services.Data
{
    public class MatchupService : IMatchupService
    {
        private readonly MatchupRepositoryAsync _matchupRepositoryAsync;
        private readonly HeroRepositoryAsync _heroRepositoryAsync;
        private readonly IAutoMapper _mapper;

        public MatchupService(IRepositoryAsync<Matchup> matchupRepositoryAsync, IRepositoryAsync<Hero> heroRepositoryAsync)
        {
            _matchupRepositoryAsync = (MatchupRepositoryAsync)matchupRepositoryAsync;
            _heroRepositoryAsync = (HeroRepositoryAsync)heroRepositoryAsync;
            _mapper = new AutoMapper.AutoMapper();
        }

        public async Task<IEnumerable<Matchup>> GetMatchupsAsync(int heroId)
        {
            List<Matchup> matchups = new List<Matchup>();
            var res = (await _matchupRepositoryAsync.ReadAllAsync()).FirstOrDefault(c => c.Hero.Id == heroId);
            if (res == null)
            {
                List<MatchupDto> matchupsDto = new List<MatchupDto>();
                
                string url = $"https://api.opendota.com/api/heroes/{heroId}/matchups";

                using (var httpClient = new HttpClient())
                {
                    using var response = await httpClient.GetAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    matchupsDto = JsonConvert.DeserializeObject<List<MatchupDto>>(apiResponse);
                }

                foreach (var matchup in matchupsDto)
                {
                    matchups.Add(new Matchup
                    {
                        Hero = await _heroRepositoryAsync.ReadAsync(heroId),
                        Enemy = await _heroRepositoryAsync.ReadAsync(matchup.HeroId),
                        GamesPlayed = matchup.GamesPlayed,
                        Wins = matchup.Wins,
                        WinRate = Math.Round(((double)matchup.Wins / matchup.GamesPlayed) * 100, 2)
                    });
                }

                await _matchupRepositoryAsync.CreateRangeAsync(matchups);

                return matchups;
            }

            return (await _matchupRepositoryAsync.ReadAllAsync()).Where(c => c.Hero.Id == heroId);
        }
    }
}
