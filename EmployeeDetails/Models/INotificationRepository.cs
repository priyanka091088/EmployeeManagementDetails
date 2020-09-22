using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Models
{
    public interface INotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        void AddEmployeeNotification(Notification notification, int departId);
        void ReadNotification(int notificationId);
    }
}
