using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BLL.Attributes;
using BLL.Services.Model.ViewModels;
using BLL.Services.User.ViewModels;
using TOFI.TransferObjects.Employee.DataObjects;

namespace BLL.Services.Employee.ViewModels
{
    public class EmployeeViewModel : ModelViewModel
    {
        [CustomRequired]
        [Display(Name = "Права")]
        public EmployeeRights Rights { get; set; }

        public UserViewModel User { get; set; }

        [IgnoreMap]
        [CustomRequired]
        [Display(Name = "Имя")]
        public string FirstName
        {
            get { return User.FirstName; }
            set { User.FirstName = value; }
        }

        [IgnoreMap]
        [CustomRequired]
        [Display(Name = "Отчество")]
        public string MiddleName
        {
            get { return User.MiddleName; }
            set { User.MiddleName = value; }
        }

        [IgnoreMap]
        [CustomRequired]
        [Display(Name = "Фамилия")]
        public string LastName
        {
            get { return User.LastName; }
            set { User.LastName = value; }
        }

        [IgnoreMap]
        [Display(Name = "Полное имя")]
        public string FullName => User.FullName;
    }
}