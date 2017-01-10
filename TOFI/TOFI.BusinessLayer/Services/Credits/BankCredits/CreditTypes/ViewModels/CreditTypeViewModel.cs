using System.Collections.Generic;
using System.ComponentModel;
using BLL.Attributes;
using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Credits.BankCredits.CreditRequirements.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.BankCredits.CreditTypes.ViewModels
{
    public class CreditTypeViewModel : ModelViewModel
    {
        [CustomRequired]
        [DisplayName("Название")]
        public string Name { get; set; }

        [CustomRequired]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [CustomRequired]
        [DisplayName("Ставка")]
        public double InterestRate { get; set; }

        public bool IsArchived { get; set; }

        [CustomRequired]
        [DisplayName("Размер пени")]
        public decimal FineInterest { get; set; }

        public List<CreditConditionViewModel> CreditConditions { get; set; }

        public List<CreditRequirementViewModel> CreditRequirements { get; set; }
    }
}