using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entity_Framework.Repository
{
    public class SongRepositoryAsync : AbstractBaseRepository<Song>
    {
        public SongRepositoryAsync(DatabaseContext databaseContext) : base(databaseContext) {}

        public override DbSet<Song> GetTable()
        {
            return _databaseContext.Songs;
        }

        public async override Task<Song> ReadAsync(int id)
        {
            return await _databaseContext.Songs.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
