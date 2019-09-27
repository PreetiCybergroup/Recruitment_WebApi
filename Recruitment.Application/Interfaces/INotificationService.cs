using Recruitment.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Application.Interfaces
{
   public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
