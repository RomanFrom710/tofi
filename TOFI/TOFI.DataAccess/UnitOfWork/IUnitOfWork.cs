using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Model;
using DAL.Repositories.Model.Models;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IModelRepository<TModel> Repository<TModel>() where TModel : class, IModel;

        int Save();
    }
}
