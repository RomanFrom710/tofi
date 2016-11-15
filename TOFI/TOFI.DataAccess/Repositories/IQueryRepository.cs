using TOFI.TransferObjects;

namespace DAL.Repositories
{
    public interface IQueryRepository<TQuery, TDto> where TQuery : Query where TDto : Dto
    {
        TDto Handle(TQuery query);
    }
}