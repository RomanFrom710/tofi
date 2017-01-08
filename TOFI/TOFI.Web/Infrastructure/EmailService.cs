using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TOFI.Web.Infrastructure
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var service = new BLL.Services.Email.EmailService();
            return service.SendEmailAsync(message.Destination, message.Subject, message.Body);
        }
    }
}