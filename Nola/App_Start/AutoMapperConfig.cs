using AutoMapper;
using Ninject;
using Nola.App_Start;
using Nola.Core.Mappings;
using Nola.Mappings;

namespace Nola
{
    public static class AutoMapperBootstrapper
    {
        //private static IKernel kernel;
        public static void Initialize()
        {
            //kernel = new StandardKernel(new ServiceModule());  
            Mapper.AssertConfigurationIsValid();
            Configure();           
        }

        public static void Configure()
        {
            //Mapper.Configuration.ConstructServicesUsing((type) => NinjectWebCommon.Kernel.Get(type));
            Mapper.Initialize(m =>
            {
                m.ConstructServicesUsing((type) => NinjectWebCommon.Kernel.Get(type));
                m.AddProfile<DomainToModelsMappings>();
                m.AddProfile<ViewModelsToDomainMappings>();
                m.AddProfile<DomainToViewModelsMappings>();
            });
        } 
    }
}