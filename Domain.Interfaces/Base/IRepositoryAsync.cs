using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Base
{
    public interface IRepositoryAsync<T>
    {
        public Task CreateAsync(T t);

        public Task<IQueryable<T>> ReadAllAsync();

        public Task<T> ReadAsync(int id);

        public Task UpdateAsync(T t);

        public Task DeleteAsync(int id);
    }
}
