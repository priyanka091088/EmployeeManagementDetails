﻿using EmployeeDetails.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
                string dept = _context.employee.Include(e => e.Department).Where(e => e.Email == this.Context.User.Identity.Name).
                    First().Department.DepartName;
                var grpName = "Employee" + dept;
                await this.Groups.AddToGroupAsync(this.Context.ConnectionId, "Employee");
            }
            await base.OnConnectedAsync();
        }
    }
}
