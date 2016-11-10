using System;

namespace DAL.Repositories
{
    public interface IRepository : IDisposable
    {
        int Save();
    }
}