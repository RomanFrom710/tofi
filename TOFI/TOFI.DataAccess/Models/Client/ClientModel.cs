﻿using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;
using System;
using TOFI.TransferObjects.Client.Enums;
using DAL.Models.Credits.CreditRequest;
using System.Collections.Generic;
using AutoMapper;
using DAL.Models.Credits.CreditAccount;

namespace DAL.Models.Client
{
    [Table("Clients")]
    public class ClientModel : Model
    {
        public string Address { get; set; }

        public string TelephoneNumber { get; set; }

        public string PassportNumber { get; set; }

        public string PassportId { get; set; }

        public string Authority { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime Birthday { get; set; }

        public Sex Sex { get; set; }

        #region Virtual Properties

        [IgnoreMap]
        public virtual UserModel User { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditRequestModel> CreditRequests { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditAccountModel> CreditAccounts { get; set; }

        #endregion
    }
}