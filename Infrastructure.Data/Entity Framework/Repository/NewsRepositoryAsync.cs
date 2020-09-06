using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entity_Framework.Repository
{
    public class NewsRepositoryAsync : AbstractBaseRepository<News>
    {
        public NewsRepositoryAsync(DatabaseContext databaseContext) : base(databaseContext) { }

        public override DbSet<News> GetTable()
        {
            return _databaseContext.News;
        }

        public async override Task<News> ReadAsync(int id)
        {
            return await _databaseContext.News.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
