using EmployeeDetails.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Controllers
{
    [Authorize]
    public class NotificationController:Controller
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public NotificationController(INotificationRepository notificationRepository,UserManager<IdentityUser> userManager)
        {
            _notificationRepository = notificationRepository;
            _userManager = userManager;
        }

        public IActionResult GetNotification()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var notification = _notificationRepository.GetUserNotifications(userId);
            return Ok(new { UserNotification = notification, Count = notification.Count });
        }
        public IActionResult ReadNotification(int notifiactionId)
        {
            _notificationRepository.ReadNotification(notifiactionId);
            return Ok();
        }
    }
}
