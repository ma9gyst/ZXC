using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateUserAsync(AppUser user);
        public Task UpdateUserAsync(AppUser user);
        public Task<AppUser> GetUser(int id);

        public Task<IEnumerable<Picture>> GetPictures(int id);
        public Task<IEnumerable<AppUser>> GetAllUsersAsync();

    }
}