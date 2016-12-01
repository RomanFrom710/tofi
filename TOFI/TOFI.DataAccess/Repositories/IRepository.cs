using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository : IDisposable
    {
        int Save();

        Task<int> SaveAsync();
    }
}