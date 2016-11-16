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
        where TUser : UserModel, new() where TUserDto : UserDto
    {
        protected UserQueryRepository(TofiContext context) : base(context)
        {
        }


        public UserInfoDto Handle(UserInfoQuery query)
        {
            TUser resModel = null;
            if (query.Id.HasValue)
            {
                resModel = ModelsDao.Find(query.Id.Value);
            }
            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                resModel = ModelsDao.FirstOrDefault(user => user.Auth.Email == query.Email);
            }
            if (!string.IsNullOrWhiteSpace(query.Username))
            {
                resModel = ModelsDao.FirstOrDefault(user => user.Auth.Username == query.Username);
            }
            return resModel == null ? null : Mapper.Map<UserInfoDto>(resModel);
        }
    }
}