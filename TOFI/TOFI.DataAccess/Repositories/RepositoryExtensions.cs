using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DAL.Repositories
{
    public static class RepositoryExtensions
    {
        public static IEnumerable<T> MapTo<T>(this IQueryable<object> queryable)
        {
            return queryable.ToArray().Select(Mapper.Map<T>);
        }

        public static IEnumerable<T> MapTo<T>(this IEnumerable<object> enumerable)
        {
            return enumerable.ToArray().Select(Mapper.Map<T>);
        }


        public static async Task<IEnumerable<T>> MapToAsync<T>(this IQueryable<object> queryable)
        {
            return (await queryable.ToArrayAsync()).Select(Mapper.Map<T>);
        }
    }
}