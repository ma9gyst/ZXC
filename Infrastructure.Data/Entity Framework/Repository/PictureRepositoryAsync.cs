using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entity_Framework.Repository
{
    public class PictureRepositoryAsync : AbstractBaseRepository<Picture>
    {

        public PictureRepositoryAsync(DatabaseContext databaseContext) : base(databaseContext) { }

        public override DbSet<Picture> GetTable()
        {
            return _databaseContext.Pictures;
        }

        public async override Task<Picture> ReadAsync(int id)
        {
            return await _databaseContext.Pictures.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Picture t)
        {
            _databaseContext.Entry(t).State = EntityState.Added;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _databaseContext.Entry(await ReadAsync(id)).State = EntityState.Deleted;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Picture>> ReadAllAsync()
        {
            return await _databaseContext.Pictures.ToListAsync();
        }

        //public async Task<Picture> ReadAsync(int id)
        //{
        //    return await _databaseContext.Pictures.FirstOrDefaultAsync(c => c.Id == id);
        //}

        public async Task Update(Picture t)
        {
            var pic = await ReadAsync(t.Id);

            pic.Name = t.Name;
            pic.Path = t.Path;
            pic.Author = t.Author;

            await _databaseContext.SaveChangesAsync();
        }
    }
}
