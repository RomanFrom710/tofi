using AutoMapper.Configuration;
using AutoMapper.Mappers;

namespace DAL.Mapping
{
    public static class MapperConfig
    {
        public static void LoadConfig(ref MapperConfigurationExpression config)
        {
            //if there is any naming conventions for specified classes, conventions can be applied
            //description's here --> https://github.com/AutoMapper/AutoMapper/wiki/Conventions 

            //cfg.CreateMap<Source, Dest>(); - simple mapping example

            config.AddConditionalObjectMapper().Where((s, d) => s.Name.Replace("Model", "Dto") == d.Name);
            config.AddConditionalObjectMapper().Where((s, d) => s.Name.Replace("Dto", "Model") == d.Name);
        }
    }
}
