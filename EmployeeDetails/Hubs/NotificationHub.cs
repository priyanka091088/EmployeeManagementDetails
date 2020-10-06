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
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        public NotificationHub(AppDbContext context,UserManager<IdentityUser> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }
       
       /* public async Task EditProfileMessage(string name,string surname)
        {
           
            var group1 = "Admin";
            var group2 = "HR";
            await Clients.Groups(group1, group2).SendAsync("RecieveEditProfileMessage", name ,surname);
        }*/

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
