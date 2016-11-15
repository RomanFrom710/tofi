using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contexts;
using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.Model.Queries;

namespace DAL.Repositories.Model
{
    public abstract class ModelQueryRepository<TModel, TModelDto> : ModelRepository<TModel>, IModelQueryRepository<TModelDto>
        where TModel : Models.Model where TModelDto : ModelDto
    {
        protected ModelQueryRepository(TofiContext context) : base(context)
        {
        }


        public IQueryable<TModelDto> Handle(AllModelsQuery query)
        {
            return ModelsDao.ProjectTo<TModelDto>();
        }

        public TModelDto Handle(ModelQuery query)
        {
            return Mapper.Map<TModelDto>(ModelsDao.Find(query.Id));
        }
    }
}