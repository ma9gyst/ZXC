using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entity_Framework.Repository.Base
{
    public abstract class AbstractBaseRepository<T> : IRepositoryAsync<T> where T : class
    {
        protected readonly DatabaseContext _databaseContext;

        public AbstractBaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public abstract DbSet<T> GetTable();

        public abstract Task<T> ReadAsync(int id);

        public async Task CreateAsync(T t)
        {
            _databaseContext.Entry(t).State = EntityState.Added;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _databaseContext.Entry(ReadAsync(id)).State = EntityState.Deleted;
            await _databaseContext.SaveChangesAsync();
        }



        public async Task<IQueryable<T>> ReadAllAsync()
        {
            return GetTable().AsNoTracking();
        }

        public async Task UpdateAsync(T t)
        {
            _databaseContext.Entry(t).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }
    }
}
