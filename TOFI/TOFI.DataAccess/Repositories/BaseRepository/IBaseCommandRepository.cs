using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.BaseRepository
{
    public interface IBaseCommandRepository : IDisposable
    {
        int Save();
    }
}
