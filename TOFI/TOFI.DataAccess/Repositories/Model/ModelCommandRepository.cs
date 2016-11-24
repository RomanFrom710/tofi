using System;
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
            Save();
            command.ModelDto.Id = model.Id;
        }

        public void Execute(UpdateModelCommand<TModelDto> command)
        {
            // if we requested a model with certain then
            // context already has an attached model with this id
            // therefore we have to find it or we will get key conflict
            var model = ModelsDao.Find(command.ModelDto.Id);
            if (model == null)
            {
                throw new ArgumentException("Model with given Id not found");
            }
            Mapper.Map(command.ModelDto, model);
            Context.Entry(model).State = EntityState.Modified;
            Save();
        }

        public void Execute(DeleteModelCommand command)
        {
            var model = new TModel {Id = command.Id};
            ModelsDao.Remove(model);
            Save();
        }
    }
}