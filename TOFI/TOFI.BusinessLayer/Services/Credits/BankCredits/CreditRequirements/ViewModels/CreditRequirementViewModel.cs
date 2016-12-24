using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.BankCredits.CreditRequirements.ViewModels
{
    public class CreditRequirementViewModel : ModelViewModel
    {
        public string Description { get; set; }

        public string ExpectedValue { get; set; }
    }
}