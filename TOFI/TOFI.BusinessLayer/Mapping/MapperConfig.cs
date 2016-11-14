using AutoMapper.Configuration;

namespace BLL.Mapping
{
    public static class MapperConfig
    {
        public static void LoadConfig(ref MapperConfigurationExpression config)
        {
            DAL.Mapping.MapperConfig.LoadConfig(ref config);

            //cfg.CreateMap<Source, Dest>(); - simple mapping example
        }
    }
}
