using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Entity_Framework.Repository
{
    public class UserRepositoryAsync : AbstractBaseRepository<AppUser>
    {
        public UserRepositoryAsync(DatabaseContext databaseContext) : base(databaseContext) { }

        public override DbSet<AppUser> GetTable()
        {
            return _databaseContext.Users;
        }

        public async override Task<AppUser> ReadAsync(int id)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
