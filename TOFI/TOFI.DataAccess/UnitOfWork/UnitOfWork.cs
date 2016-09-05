using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Repositories;
using DAL.Repositories.Model;
using DAL.Repositories.Model.Models;

namespace DAL.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly TofiContext _context;
        private readonly Dictionary<Type, IModelRepository<IModel>> _repositories;

        public UnitOfWork(TofiContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, IModelRepository<IModel>>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IModelRepository<TModel> Repository<TModel>() where TModel : class, IModel
        {
            if (_repositories.ContainsKey(typeof (TModel)))
            {
                return _repositories[typeof (TModel)] as IModelRepository<TModel>;
            }
            var repository = new ModelRepository<TModel>(_context);
            _repositories.Add(typeof (TModel), repository as IModelRepository<IModel>);
            return repository;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}