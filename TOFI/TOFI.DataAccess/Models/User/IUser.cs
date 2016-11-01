using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;

namespace DAL.Models
{
    public interface IUser: IModel
    {
        string Username { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
    }
}
