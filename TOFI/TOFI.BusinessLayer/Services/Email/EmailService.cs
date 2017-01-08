using System;
using System.Configuration;
using System.Threading.Tasks;
using NLog;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BLL.Services.Email
{
    public class EmailService : Service, IEmailService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
            try
            {
                var sg = new SendGridAPIClient(_apiKey);

                var emailFrom = new SendGrid.Helpers.Mail.Email(_from, "Home Chaley Bank");
                var emailTo = new SendGrid.Helpers.Mail.Email(to);
                var emailContent = new Content(contentType, content);
                var mail = new Mail(emailFrom, subject, emailTo, emailContent);

                await sg.client.mail.send.post(requestBody: mail.Get());
            }
            catch (Exception ex)
            {
                Logger.Error($"Can't send email to {to} about {subject}: {ex.Message}");
            }
        }

        public Task SendTextAsync(string to, string subject, string text)
        {
            return SendAsync(to, subject, text, "text/plain");
        }

        public Task SendEmailAsync(string to, string subject, string body)
        {
            return SendAsync(to, subject, body, "text/html");
        }

        public Task SendLockoutNotification(string to, DateTimeOffset lockoutEnd)
        {
            return SendTextAsync(to, "Блокировка аккаунта",
                "Ваш аккаунт был заблокирован в связи " +
                "с превышением максимального числа неверных попыток входа. " +
                $"Дата окончания блокировки: {lockoutEnd.LocalDateTime:G}");
        }

        public Task SendRequestApprovedNotification(string to)
        {
            return SendTextAsync(to, "Заявка на кредит",
                "Ваша заявка на кредит была утверждена. " +
                "Ждем вас с паспортом в любом отделении нашего банка.");
        }
    }
}