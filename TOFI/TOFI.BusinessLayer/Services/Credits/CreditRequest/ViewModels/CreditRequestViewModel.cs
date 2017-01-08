using System.ComponentModel.DataAnnotations;
using BLL.Attributes;
using BLL.Services.Client.ViewModels;
using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Employee.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.CreditRequest.ViewModels
{
    public class CreditRequestViewModel : ModelViewModel
    {
        #region Approved

        public bool? IsOperatorApproved { get; set; }

        public bool? IsSecurityApproved { get; set; }

        public bool? IsCreditCommitteeApproved { get; set; }

        public bool? IsCreditDepartmentApproved { get; set; }

        #endregion

        #region Comments

        public string OperatorComments { get; set; }

        public string SecurityComments { get; set; }

        public string CreditCommitteeComments { get; set; }

        public string CreditDepartmentComments { get; set; }

        public string CashierComments { get; set; }

        #endregion

        #region Condition

        [CustomRequired]
        [Display(Name = "Количество месяцев")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество месяцев должно быть положительным.")]
        public int MonthDuration { get; set; }

        [Display(Name = "Сумма кредита")]
        public PriceViewModel CreditSum { get; set; }

        [CustomRequired]
        [Display(Name = "Цель получения кредита")]
        public string CreditPurpose { get; set; }

        [Display(Name = "Заявка создана")]
        public bool? IsOpen { get; set; }

        #endregion

        #region Virtual Properties 

        public ClientViewModel Client { get; set; }

        public EmployeeViewModel OperatorApproved { get; set; }

        public EmployeeViewModel SecurityApproved { get; set; }

        public EmployeeViewModel CreditCommitteeApproved { get; set; }

        public EmployeeViewModel CreditDepartmentApproved { get; set; }

        [Display(Name = "Кредит")]
        public CreditTypeViewModel CreditType { get; set; }

        public EmployeeViewModel RequestOpener { get; set; }

        #endregion
    }
}