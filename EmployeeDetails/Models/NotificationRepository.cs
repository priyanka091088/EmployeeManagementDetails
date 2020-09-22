using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*using System.Linq;
using System.Threading.Tasks;
using EmployeeDetails.Hubs;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;*/

namespace EmployeeDetails.Models
{
    public class NotificationRepository : INotificationRepository
    {
        public readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmployeeRepository _employeeRepository;
        public NotificationRepository(AppDbContext context,UserManager<IdentityUser> _userManager,IEmployeeRepository employeeRepository)
             
        {
            _context = context;
            userManager = _userManager;
            _employeeRepository = employeeRepository;
        }
        public void AddEmployeeNotification(Notification notification, int departId)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            
            var employees = _employeeRepository.SelectAllEmployees().ToList();
            var employeeList = employees.Where(x => x.DepartId == departId);
            foreach (var emp in employeeList)
            {
                var user = userManager.FindByEmailAsync(emp.Email).Result;
                var usernotification = new NotificationApplicationUser();
                usernotification.ApplicationUserId = user.Id;
                usernotification.NotificationId = notification.id;

                _context.UserNotifications.Add(usernotification);
                _context.SaveChanges();
            }
        }

        public List<NotificationApplicationUser> GetUserNotifications(string userId)
        {
            return _context.UserNotifications.Where(u => u.ApplicationUserId.Equals(userId))
                                            .Include(n => n.Notification)
                                            .ToList();
        }

        public void ReadNotification(int notificationId)
        {
            var notification = _context.Notifications.FirstOrDefault(n => n.id == notificationId);
            notification.IsRead = true;
            _context.Notifications.Update(notification);
            _context.SaveChanges();

        }
    }
}
