using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BLL.Attributes;
using BLL.Services.Model.ViewModels;
using BLL.Services.User.ViewModels;
using TOFI.TransferObjects.Client.Enums;

namespace BLL.Services.Client.ViewModels
{
    public class ClientViewModel : ModelViewModel
    {
        [CustomRequired]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [CustomRequired]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [CustomRequired]
        [Display(Name = "Номер телефона")]
        public string TelephoneNumber { get; set; }

        [CustomRequired]
        [Display(Name = "Серия и номер паспорта")]
        [RegularExpression(@"^[A-Z|А-Я]{2}\d{7}$", ErrorMessage = "Пожалуйста, введите номер в формате AB1234567")]
        public string PassportNumber { get; set; }

        [CustomRequired]
        [Display(Name = "Идентификационный номер")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} должен быть длиной {1} символов")]
        public string PassportId { get; set; }

        [CustomRequired]
        [Display(Name = "Гражданство")]
        public string Authority { get; set; }

        [CustomRequired]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Birthday { get; set; }

        [CustomRequired]
        [Display(Name = "Дата выдачи")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? IssueDate { get; set; }

        [CustomRequired]
        [Display(Name = "Действителен до")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpirationDate { get; set; }

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

        [IgnoreMap]
        public int Age
        {
            get
            {
                var now = DateTime.Now;
                if (!Birthday.HasValue)
                {
                    return 0;
                }

                var delta = now - Birthday.Value;
                return (int)Math.Floor(delta.TotalDays/365);
            }
        }
    }
}