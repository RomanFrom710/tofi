using System.Data.Entity;
using AutoMapper;
using DAL.Contexts;
using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Model.DataObjects;

namespace DAL.Repositories.Model
{
    public abstract class ModelCommandRepository<TModel, TModelDto> : ModelRepository<TModel>, IModelCommandRepository<TModelDto>
        where TModel : Models.Model, new() where TModelDto : ModelDto
    {
        protected ModelCommandRepository(TofiContext context) : base(context)
        {
        }


        public void Execute(CreateModelCommand<TModelDto> command)
        {
            var model = Mapper.Map<TModel>(command.ModelDto);
            ModelsDao.Add(model);
        }

        public void Execute(UpdateModelCommand<TModelDto> command)
        {
            var model = Mapper.Map<TModel>(command.ModelDto);
            Context.Entry(model).State = EntityState.Modified;
        }

        public void Execute(DeleteModelCommand command)
        {
            var model = new TModel {Id = command.Id};
            ModelsDao.Remove(model);
        }
    }
}