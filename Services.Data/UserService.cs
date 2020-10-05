using Domain.Core.Entities;
using Domain.Interfaces.Base;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<AppUser> _repositoryAsync;

        public UserService(IRepositoryAsync<AppUser> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _repositoryAsync.ReadAllAsync();
        }

        public async Task UpdateUserAsync(AppUser User)
        {
            await _repositoryAsync.UpdateAsync(User);
        }

        public async Task CreateUserAsync(AppUser User)
        {
            await _repositoryAsync.CreateAsync(User);
        }

        public async Task<AppUser> GetUser(int id)
        {
            return await _repositoryAsync.ReadAsync(id);
        }

        public async Task<IEnumerable<Picture>> GetPictures(int id)
        {
            return (await _repositoryAsync.ReadAsync(id)).Pictures;
        }

    }
}
