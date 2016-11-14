using AutoMapper.Configuration;

namespace DAL.Mapping
{
    public static class MapperConfig
    {
        public static void LoadConfig(ref MapperConfigurationExpression config)
        {
            //if there is any naming conventions for specified classes, conventions can be applied
            //description's here --> https://github.com/AutoMapper/AutoMapper/wiki/Conventions 

            //cfg.CreateMap<Source, Dest>(); - simple mapping example
            config.CreateMap<Models.User.UserModel, TOFI.TransferObjects.User.DataObjects.LoginDto>();
            config.CreateMap<Models.User.UserModel, TOFI.TransferObjects.User.DataObjects.UserDto>();
        }
    }
}
