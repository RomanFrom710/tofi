using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Contexts;
using DAL.Models;

namespace DAL.Repositories.Model
{
    public class ModelRepository<TModel> : IModelRepository<TModel>
        where TModel : class, IModel
    {
        private readonly TofiContext _context;
        private readonly DbSet<TModel> _db;

        public ModelRepository(TofiContext context)
        {
            _context = context;
            _db = context.Set<TModel>();
        } 

        public virtual TModel GetModel(int id)
        {
            return _db == null ? null : _db.Find(id);
        }

        public virtual IEnumerable<TModel> GetAllModels()
        {
            return _db;
        }

        public virtual TModel GetModel(Predicate<TModel> predicate)
        {
            return _db == null ? null : _db.FirstOrDefault(m => predicate(m));
        }

        public virtual IEnumerable<TModel> GetModels(Predicate<TModel> predicate)
        {
            return _db == null ? null : _db.Where(m => predicate(m));
        }

        public virtual TModel Add(TModel model)
        {
            return _db.Add(model);
        }

        public virtual TModel Update(TModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return model;
        }

        public virtual TModel Delete(TModel model)
        {
            return _db.Remove(model);
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}