using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace BLL.Emails
{
    public abstract class EmailService
    {
        #region Properties

        private string _apiKey;
        private string _from;

        #endregion

        #region Constructors

        public EmailService(string apiKey, string from)
        {
            _apiKey = apiKey;
            _from = from;
        }

        #endregion

        public async Task<dynamic> SendEmailAsync(string to, string subject, string content)
        {
            var sg = new SendGridAPIClient(_apiKey);
            
            Email emailFrom = new Email(_from);
            Email emailTo = new Email("test@example.com");
            Content emailContent = new Content("text/plain", content);
            Mail mail = new Mail(emailFrom, subject, emailTo, emailContent);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
            return response;
        }
    }
}
