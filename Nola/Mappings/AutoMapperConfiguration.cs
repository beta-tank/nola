using AutoMapper;

namespace Nola.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DomainToModelsMappings>();
            });
        } 
    }
}