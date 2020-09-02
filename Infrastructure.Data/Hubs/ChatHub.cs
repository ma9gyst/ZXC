using Domain.Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(AppUser user, Message message) 
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
