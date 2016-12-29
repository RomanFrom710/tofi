using System.Collections.Generic;
using System.Threading.Tasks;
using TOFI.TransferObjects;

namespace DAL.Repositories
{
    public interface IListQueryRepository<TQuery, TDto> where TQuery : Query where TDto : Dto
    {
        IEnumerable<TDto> Handle(TQuery query);

        Task<IEnumerable<TDto>> HandleAsync(TQuery query);
    }
}