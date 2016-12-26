using DAL.Models.User;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.User
{
    [Table("UserActions")]
    public class UserActionModel: Model
    {
        [JsonIgnore]
        public string Signature { get; set; }

        public DateTime Date { get; set; }

        #region Virtual Properties

        public virtual UserModel User { get; set; }

        #endregion
    }
}
