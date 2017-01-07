using System;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.Auth;
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


        protected override UserModel CreateDbModel(UserDto modelDto)
        {
            var model = base.CreateDbModel(modelDto);
            model.Auth = Mapper.Map<AuthModel>(modelDto.Auth);
            return model;
        }

        protected override void UpdateDbModel(UserModel model, UserDto modelDto)
        {
            if (model.Auth.Id != modelDto.Auth.Id)
            {
                throw new ArgumentException("Auth Id change is not allowed");
            }
            base.UpdateDbModel(model, modelDto);
        }
    }
}