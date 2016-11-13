using System.Linq;
using DAL.Contexts;
using DAL.Models.User;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public abstract class UserQueryRepository<TUser> : ModelRepository<TUser>, IUserQueryRepository
        where TUser : UserModel
    {
        protected UserQueryRepository(TofiContext context) : base(context)
        {
        }


        public IQueryable<LoginDto> Handle(LoginQuery query)
        {
            IQueryable<TUser> resModels = null;
            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                resModels = ModelsDao.Where(user => user.Email == query.Email);
            }
            if (!string.IsNullOrWhiteSpace(query.Username))
            {
                resModels = ModelsDao.Where(user => user.Username == query.Username);
            }
            if (resModels == null)
            {
                return Enumerable.Empty<LoginDto>().AsQueryable();
            }
            var res = resModels.Select(
                model => new LoginDto
                {
                    Id = model.Id,
                    Email = model.Email,
                    Username = model.Username,
                    PasswordHash = model.PasswordHash,
                    FailedLogonCnt = model.FailedLogonCnt,
                    NextLogonTime = model.NextLogonTime
                });
            return res;
        }

        public IQueryable<UserDto> Handle(UserQuery query)
        {
            IQueryable<TUser> resModels = null;
            if (query.Id.HasValue)
            {
                resModels = ModelsDao.Where(user => user.Id == query.Id.Value);
            }
            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                resModels = ModelsDao.Where(user => user.Email == query.Email);
            }
            if (!string.IsNullOrWhiteSpace(query.Username))
            {
                resModels = ModelsDao.Where(user => user.Username == query.Username);
            }
            if (resModels == null)
            {
                return Enumerable.Empty<UserDto>().AsQueryable();
            }
            var res = resModels.Select(
                model => new UserDto()
                {
                    Id = model.Id,
                    Email = model.Email,
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailConfirmed = model.EmailConfirmed
                });
            return res;
        }
    }
}