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

            config.CreateMap<Models.Auth.AuthModel, TOFI.TransferObjects.Auth.DataObjects.AuthDto>();
            config.CreateMap<Models.User.UserModel, TOFI.TransferObjects.User.DataObjects.UserDto>();
            config.CreateMap<Models.Admin.AdminModel, TOFI.TransferObjects.Admin.DataObjects.AdminDto>();
            config.CreateMap<Models.Client.ClientModel, TOFI.TransferObjects.Client.DataObjects.ClientDto>();
            config.CreateMap<Models.Employee.EmployeeModel, TOFI.TransferObjects.Employee.DataObjects.EmployeeDto>();

            config.CreateMap<TOFI.TransferObjects.Auth.DataObjects.AuthDto, Models.Auth.AuthModel>();
            config.CreateMap<TOFI.TransferObjects.User.DataObjects.UserDto, Models.User.UserModel>();
            config.CreateMap<TOFI.TransferObjects.Admin.DataObjects.AdminDto, Models.Admin.AdminModel>();
            config.CreateMap<TOFI.TransferObjects.Client.DataObjects.ClientDto, Models.Client.ClientModel>();
            config.CreateMap<TOFI.TransferObjects.Employee.DataObjects.EmployeeDto, Models.Employee.EmployeeModel>();
        }
    }
}
