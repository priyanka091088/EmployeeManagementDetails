using EmployeeDetails.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Hubs
{
    public class NotificationHub:Hub
    {
        
        public async Task SendMessage(string Name, string Surname)
        {
           var group = "Employee";
            await Clients.Group(group).SendAsync("sendToUser", Name, Surname);
        }

        public async Task EditProfileMessage(string name,string surname)
        {
            var group1 = "Admin";
            var group2 = "HR";
            await Clients.Groups(group1, group2).SendAsync("RecieveEditProfileMessage", name,surname);
        }

        public async Task AddDepartmentMessage(string name)
        {
            
            var group = "HR";
            await Clients.Group(group).SendAsync("RecieveAddDepartMessage", name);
        }

        public override async Task OnConnectedAsync()
        {
            if (this.Context.User.IsInRole("Admin"))
            {
                await this.Groups.AddToGroupAsync(this.Context.ConnectionId, "Admin");
            }
            else if (this.Context.User.IsInRole("HR"))
            {
                await this.Groups.AddToGroupAsync(this.Context.ConnectionId, "HR");
            }
            else if (this.Context.User.IsInRole("Employee"))
            {
                await this.Groups.AddToGroupAsync(this.Context.ConnectionId, "Employee");
            }
            await base.OnConnectedAsync();
        }
    }
}
