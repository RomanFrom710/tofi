using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public class UserQueryRepository : ModelQueryRepository<UserModel, UserDto>, IUserQueryRepository
    {
        public UserQueryRepository(TofiContext context) : base(context)
        {
        }


        public UserDto Handle(UserQuery query)
        {
            UserModel model = null;
            if (query.Id.HasValue)
            {
                model = ModelsDao.Find(query.Id.Value);
            }
            if (!string.IsNullOrEmpty(query.Email))
            {
                model = ModelsDao.FirstOrDefault(u => u.Email == query.Email);
            }
            if (!string.IsNullOrEmpty(query.Username))
            {
                model = ModelsDao.FirstOrDefault(u => u.Username == query.Username);
            }
            return model == null ? null : Mapper.Map<UserDto>(model);
        }

        public async Task<UserDto> HandleAsync(UserQuery query)
        {
            UserModel model = null;
            if (query.Id.HasValue)
            {
                model = await ModelsDao.FindAsync(query.Id.Value);
            }
            if (!string.IsNullOrEmpty(query.Email))
            {
                model = await ModelsDao.FirstOrDefaultAsync(u => u.Email == query.Email);
            }
            if (!string.IsNullOrEmpty(query.Username))
            {
                model = await ModelsDao.FirstOrDefaultAsync(u => u.Username == query.Username);
            }
            return model == null ? null : Mapper.Map<UserDto>(model);
        }
    }
}