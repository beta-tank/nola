using AutoMapper;

namespace Nola.Mappings
{
    public static class AutoMapperBootstrapper
    {
        public static void Initialize()
        {
            Mapper.AssertConfigurationIsValid();
            Configure();
        }

        public static void Configure()
        {
            Mapper.Initialize(m => m.AddProfile<DomainToModelsMappings>());
        } 
    }
}