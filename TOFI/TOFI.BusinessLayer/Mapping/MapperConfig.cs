using AutoMapper.Configuration;
using AutoMapper.Mappers;

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
        }
    }
}
