using System.Security.Claims;
using AutoMapper;
using Nola.Core.Models.Users;

namespace Nola.Core.Mappings
{
    public class DomainToModelsMappings : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToModelsMappings"; }
        }

        protected override void Configure()
        {
            base.Configure();
            Mapper.CreateMap<ApplicationClaim, Claim>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForAllMembers(opt => opt.Ignore());
        }
    }
}