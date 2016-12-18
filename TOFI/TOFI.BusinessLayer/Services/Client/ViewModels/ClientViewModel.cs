using System.ComponentModel.DataAnnotations;
using BLL.Services.User.ViewModels;

namespace BLL.Services.Client.ViewModels
{
    public class ClientViewModel : UserViewModel
    {
        [Required]
        public string DocumentNumber { get; set; }

        [Required]
        public string DocumentInfo { get; set; }

        [Required]
        public string Address { get; set; }
    }
}