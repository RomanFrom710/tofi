using System;
using System.Threading.Tasks;

namespace BLL.Services.Email
{
    public interface IEmailService : IService
    {
        Task SendAsync(string to, string subject, string content, string contentType);

        Task SendTextAsync(string to, string subject, string text);

        Task SendEmailAsync(string to, string subject, string body);

        Task SendLockoutNotification(string to, DateTimeOffset lockoutEnd);
    }
}