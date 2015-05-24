using System.Collections.Generic;
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
        public ViewModelsToDomainMappings()
        {
           
        }

        public override string ProfileName
        {
            get { return "ViewModelsToDomainMappings"; }
        }

        protected override void Configure()
        {
            base.Configure();
            Mapper.CreateMap<RegisterStudentViewModel, StudentUser>()
                .ForMember(x => x.School, opt => opt.ResolveUsing<SchoolResolver>().FromMember(x => x.SchoolId))
                .ForMember(x => x.TimeZoneInfoId, opt => opt.MapFrom(x => x.TimeZoneId));

            Mapper.CreateMap<RegisterTeacherViewModel, TeacherUser>()
                .ForMember(x => x.Subjects, opt => opt.ResolveUsing<SubjectResolver>().FromMember(x => x.SubjectIds))
                .ForMember(x => x.TimeZoneInfoId, opt => opt.MapFrom(x => x.TimeZoneId));

            //Mapper.CreateMap<RegisterStudentViewModel, StudentUser>()
            //    .ForMember(x => x.School, opt => opt.ResolveUsing(new SchoolResolver()).FromMember(x => x.SchoolId))
            //    .ForMember(x => x.TimeZoneInfoId, opt => opt.MapFrom(x => x.TimeZoneId));

            //Mapper.CreateMap<RegisterTeacherViewModel, TeacherUser>()
            //    .ForMember(x => x.Subjects, opt => opt.ResolveUsing(new SubjectResolver()).FromMember(x => x.SubjectIds))
            //    .ForMember(x => x.TimeZoneInfoId, opt => opt.MapFrom(x => x.TimeZoneId));

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

    public class SubjectResolver : ValueResolver<IEnumerable<int>, IEnumerable<Subject>>
    {
        private readonly ISubjectService service;

        [Inject]
        public SubjectResolver(ISubjectService service)
        {
            this.service = service;
        }

        protected override IEnumerable<Subject> ResolveCore(IEnumerable<int> source)
        {
            return service.GetSubjects(source);
        }
    }
}