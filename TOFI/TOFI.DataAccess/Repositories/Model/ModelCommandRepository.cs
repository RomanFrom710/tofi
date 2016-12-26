using System;
using System.Data.Entity;
using System.Threading.Tasks;
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
            Mapper.Map(model, command.ModelDto);
        }

        public async Task ExecuteAsync(CreateModelCommand<TModelDto> command)
        {
            var model = Mapper.Map<TModel>(command.ModelDto);
            ModelsDao.Add(model);
            await SaveAsync();
            Mapper.Map(model, command.ModelDto);
        }

        public void Execute(UpdateModelCommand<TModelDto> command)
        {
            // if we requested a model with certain then
            // context already has an attached model with this id
            // therefore we have to find it or we will get key conflict
            var model = ModelsDao.Find(command.ModelDto.Id);
            if (model == null)
            {
                throw new ArgumentException($"{typeof(TModel).Name} with given Id not found");
            }
            Mapper.Map(command.ModelDto, model);
            Context.Entry(model).State = EntityState.Modified;
            Save();
            Mapper.Map(model, command.ModelDto);
        }

        public async Task ExecuteAsync(UpdateModelCommand<TModelDto> command)
        {
            var model = await ModelsDao.FindAsync(command.ModelDto.Id);
            if (model == null)
            {
                throw new ArgumentException($"{typeof(TModel).Name} with given Id not found");
            }
            Mapper.Map(command.ModelDto, model);
            Context.Entry(model).State = EntityState.Modified;
            await SaveAsync();
            Mapper.Map(model, command.ModelDto);
        }

        public void Execute(DeleteModelCommand command)
        {
            var model = ModelsDao.Find(command.Id);
            if (model == null)
            {
                throw new ArgumentException($"{typeof(TModel).Name} with given Id not found");
            }
            ModelsDao.Remove(model);
            Save();
        }

        public async Task ExecuteAsync(DeleteModelCommand command)
        {
            var model = await ModelsDao.FindAsync(command.Id);
            if (model == null)
            {
                throw new ArgumentException($"{typeof(TModel).Name} with given Id not found");
            }
            ModelsDao.Remove(model);
            await SaveAsync();
        }
    }
}