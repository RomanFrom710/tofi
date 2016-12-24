using System.ComponentModel.DataAnnotations;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Client.ViewModels
{
    public class ClientViewModel : ModelViewModel
    {
        [Required]
        public string DocumentNumber { get; set; }

        [Required]
        public string DocumentInfo { get; set; }

        [Required]
        public string Address { get; set; }
    }
}