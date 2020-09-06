using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entity_Framework.Repository
{
    public class MessageRepositoryAsync : AbstractBaseRepository<Message>
    {
        public MessageRepositoryAsync(DatabaseContext databaseContext) : base(databaseContext) { }

        public override DbSet<Message> GetTable()
        {
            return _databaseContext.Messages;
        }

        public async override Task<Message> ReadAsync(int id)
        {
            return await _databaseContext.Messages.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}