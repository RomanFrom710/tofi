using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.UserRepository
{
    public interface IUserQueryRepository: IBaseQueryRepository
    {
        IUser GetUser(int id);

        IQueryable<IUser> GetUsers();
    }
}
