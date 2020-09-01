using Domain.Core.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.SignalR
{
    public class SignalRHub : Hub
    {
        public Task SendMessage(User user, Message message) 
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
