using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Models;
using DAL.Repositories.BaseRepository;

namespace DAL.Repositories.UserRepository
{
    class UserCommandRepository: BaseCommandRepository, IUserCommandRepository
    {
        private readonly TofiContext _context;
        private readonly DbSet<IUser> _db;

        public UserCommandRepository(TofiContext context): base(context)
        {
            _context = context;
            _db = context.Set<IUser>();
        }

        public IUser AddUser(IUser user)
        {
            _db.Add(user);
            return user;
        }
    }
}
