using AutoMapper;
using Ninject;
using Nola.App_Start;
using Nola.Core.Models.Education;
using Nola.Core.Models.Users;
using Nola.Service.Services;
using Nola.ViewModels;

namespace Nola.Mappings
{
    public class ViewModelsToDomainMappings : Profile
    {
        private readonly IKernel kernel;

        public ViewModelsToDomainMappings()
        {
            kernel = new StandardKernel(new ServiceModule());
        }

        public override string ProfileName
        {
            get { return "ViewModelsToDomainMappings"; }
        }

        protected override void Configure()
        {
            base.Configure();
            Mapper.CreateMap<RegisterStudentViewModel, StudentUser>()
                .ForMember(x => x.School, opt => opt.ResolveUsing(new SchoolResolver(kernel.Get<ISchoolService>())).FromMember(x => x.SchoolId))
                .ForMember(x => x.TimeZoneInfoId, opt => opt.MapFrom(x => x.TimeZoneId));

                //.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                //.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                //.ForAllMembers(opt => opt.Ignore());
        }
    }

    public class SchoolResolver : ValueResolver<int, School>
    {
        private readonly ISchoolService service;
        [Inject]
        public SchoolResolver(ISchoolService service)
        {
            this.service = service;
        }

        protected override School ResolveCore(int id)
        {
            return service.GetSchool(id);
        }
    }
}