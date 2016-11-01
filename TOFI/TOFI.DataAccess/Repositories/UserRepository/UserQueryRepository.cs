using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Models;
using DAL.Repositories.BaseRepository;

namespace DAL.Repositories.UserRepository
{
    public class UserQueryRepository: BaseQueryRepository, IUserQueryRepository
    {
        private readonly TofiContext _context;
        private readonly DbSet<IUser> _db;

        public UserQueryRepository(TofiContext context)
        {
            _context = context;
            _db = context.Set<IUser>();
        }


        public IUser GetUser(int id)
        {
            return _db == null ? null : _db.Find(id);
        }

        public IQueryable<IUser> GetUsers()
        {
            return _db;
        }
    }
}
