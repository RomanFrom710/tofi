using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories.BaseRepository;

namespace DAL.Repositories.UserRepository
{
    public interface IUserCommandRepository: IBaseCommandRepository
    {
        IUser AddUser(IUser user);
    }
}
