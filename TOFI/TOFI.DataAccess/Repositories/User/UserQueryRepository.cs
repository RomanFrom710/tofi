using System.Linq;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public abstract class UserQueryRepository<TUser, TUserDto> : ModelQueryRepository<TUser, TUserDto>, IUserQueryRepository<TUserDto>
        where TUser : UserModel where TUserDto : UserDto
    {
        protected UserQueryRepository(TofiContext context) : base(context)
        {
        }


        public TUserDto Handle(UserQuery query)
        {
            TUser model = null;
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
            return model == null ? null : Mapper.Map<TUserDto>(model);
        }
    }


    public class UserQueryRepository : UserQueryRepository<UserModel, UserDto>, IUserQueryRepository
    {
        public UserQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}