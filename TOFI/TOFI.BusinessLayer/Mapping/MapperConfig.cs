using AutoMapper.Configuration;
using AutoMapper.Mappers;
using BLL.Services.Client.ViewModels;
using BLL.Services.User.ViewModels;
using TOFI.TransferObjects.User.DataObjects;

namespace BLL.Mapping
{
    public static class MapperConfig
    {
        public static void LoadConfig(ref MapperConfigurationExpression config)
        {
            DAL.Mapping.MapperConfig.LoadConfig(ref config);

            //cfg.CreateMap<Source, Dest>(); - simple mapping example

            config.AddConditionalObjectMapper().Where((s, d) => s.Name.Replace("ViewModel", "Dto") == d.Name);
            config.AddConditionalObjectMapper().Where((s, d) => s.Name.Replace("Dto", "ViewModel") == d.Name);

            config.CreateMap<RegisterViewModel, UserDto>();
            config.CreateMap<ClientViewModel, UserViewModel>();
            config.CreateMap<UserViewModel, ClientViewModel>();
        }
    }
}
