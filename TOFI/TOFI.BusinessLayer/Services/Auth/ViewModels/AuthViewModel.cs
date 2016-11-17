using System;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Auth.ViewModels
{
    public class AuthViewModel : ModelViewModel
    {
        public int AccessFailedCnt { get; set; }

        public DateTime? LockoutDateUtc { get; set; }

        public int AccessGrantedTotal { get; set; }

        public DateTime? LastAccessGrantedDateUtc { get; set; }

        public int AccessFailedTotal { get; set; }

        public DateTime? LastAccessFailedDateUtc { get; set; }
    }
}