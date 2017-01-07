using System.Configuration;

namespace BLL.Emails
{
    public class AdministrationEmailService : EmailService
    {
        public AdministrationEmailService(string apiKey) : 
            base(ConfigurationManager.AppSettings["SendGridApiKey"],
                ConfigurationManager.AppSettings["BankEmail"])
        {
        }
        
    }
}
