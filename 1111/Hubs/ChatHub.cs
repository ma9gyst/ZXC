using Domain.Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _1111.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(AppUser user, Message message) 
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
