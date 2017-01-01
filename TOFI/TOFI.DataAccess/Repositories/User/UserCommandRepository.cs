using System;
using DAL.Contexts;
using DAL.Models.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public class UserCommandRepository : ModelCommandRepository<UserModel, UserDto>, IUserCommandRepository
    {
        public UserCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void UpdateDbModel(UserModel model, UserDto modelDto)
        {
            if (model.Auth.Id != modelDto.Auth.Id)
            {
                throw new ArgumentException("Auth Id change is not allowed");
            }
            if (model.Client.Id != modelDto.Client.Id)
            {
                throw new ArgumentException("Client Id change is not allowed");
            }
            if (model.Employee.Id != modelDto.Employee.Id)
            {
                throw new ArgumentException("Employee Id change is not allowed");
            }
        }
    }
}