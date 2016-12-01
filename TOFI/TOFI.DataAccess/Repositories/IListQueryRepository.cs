using System.Linq;
using System.Threading.Tasks;
using TOFI.TransferObjects;

namespace DAL.Repositories
{
    public interface IListQueryRepository<TQuery, TDto> where TQuery : Query where TDto : Dto
    {
        IQueryable<TDto> Handle(TQuery query);

        Task<IQueryable<TDto>> HandleAsync(TQuery query);
    }
}