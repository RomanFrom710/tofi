using System;
using TOFI.TransferObjects.Client.Enums;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Client.DataObjects
{
    public class ClientDto : ModelDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string TelephoneNumber { get; set; }

        public string PassportNumber { get; set; }

        public string PassportId { get; set; }

        public string Authority { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Sex Sex { get; set; }
    }
}