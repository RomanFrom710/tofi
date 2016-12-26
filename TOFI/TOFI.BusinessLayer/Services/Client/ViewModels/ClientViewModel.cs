using System;
using System.ComponentModel.DataAnnotations;
using BLL.Services.Model.ViewModels;
using TOFI.TransferObjects.Client.Enums;

namespace BLL.Services.Client.ViewModels
{
    public class ClientViewModel : ModelViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public string PassportNumber { get; set; }

        [Required]
        public string PassportId { get; set; }

        [Required]
        public string Authority { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? IssueDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpirationDate { get; set; }
    }
}