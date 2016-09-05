using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Contexts;

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

        public TModel GetModel(int id)
        {
            return _db == null ? null : _db.Find(id);
        }

        public IEnumerable<TModel> GetAllModels()
        {
            return _db;
        }

        public TModel GetModel(Predicate<TModel> predicate)
        {
            return _db == null ? null : _db.FirstOrDefault(m => predicate(m));
        }

        public IEnumerable<TModel> GetModels(Predicate<TModel> predicate)
        {
            return _db == null ? null : _db.Where(m => predicate(m));
        }

        public TModel Add(TModel model)
        {
            return _db.Add(model);
        }

        public TModel Update(TModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return model;
        }

        public TModel Delete(TModel model)
        {
            return _db.Remove(model);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}