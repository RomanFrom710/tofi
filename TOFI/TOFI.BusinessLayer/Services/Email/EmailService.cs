using System.Configuration;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BLL.Services.Email
{
    public class EmailService : Service, IEmailService
    {
        private readonly string _apiKey;
        private readonly string _from;


        protected EmailService(string apiKey, string from)
        {
            _apiKey = apiKey;
            _from = from;
        }

        public EmailService() : this(ConfigurationManager.AppSettings["SendGridApiKey"],
            ConfigurationManager.AppSettings["BankEmail"])
        {
        }


        public async Task SendAsync(string to, string subject, string content, string contentType)
        {
            var sg = new SendGridAPIClient(_apiKey);

            var emailFrom = new SendGrid.Helpers.Mail.Email(_from, "Home Chaley Bank");
            var emailTo = new SendGrid.Helpers.Mail.Email(to);
            var emailContent = new Content(contentType, content);
            var mail = new Mail(emailFrom, subject, emailTo, emailContent);

            await sg.client.mail.send.post(requestBody: mail.Get());
        }

        public Task SendTextAsync(string to, string subject, string text)
        {
            return SendAsync(to, subject, text, "text/plain");
        }

        public Task SendEmailAsync(string to, string subject, string body)
        {
            return SendAsync(to, subject, body, "text/html");
        }
    }
}