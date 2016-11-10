using System.Linq;
using TOFI.TransferObjects;

namespace DAL.Repositories
{
    public interface IQueryRepository<TQuery, TDto> where TQuery : IQuery where TDto : IDto
    {
        IQueryable<TDto> Handle(TQuery query);
    }
}