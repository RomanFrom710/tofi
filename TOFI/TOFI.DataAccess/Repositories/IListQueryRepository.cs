using System.Linq;
using TOFI.TransferObjects;

namespace DAL.Repositories
{
    public interface IListQueryRepository<TQuery, TDto> where TQuery : Query where TDto : Dto
    {
        IQueryable<TDto> Handle(TQuery query);
    }
}