using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;

namespace DAL.Repositories.BaseRepository
{
    public class BaseCommandRepository: IBaseCommandRepository
    {
        private readonly TofiContext _context;

        public BaseCommandRepository(TofiContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
