using System.Configuration;

namespace BLL.Emails
{
    public class AdministrationEmailService : EmailService
    {
        public AdministrationEmailService() : 
            base(ConfigurationManager.AppSettings["SendGridApiKey"],
                ConfigurationManager.AppSettings["BankEmail"])
        {
        }
        
    }
}
