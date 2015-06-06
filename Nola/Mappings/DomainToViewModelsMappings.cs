using AutoMapper;
using Nola.Core.Models.Question;
using Nola.ViewModels.Question;

namespace Nola.Mappings
{
    public class DomainToViewModelsMappings : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelsMappings"; }
        }

        protected override void Configure()
        {
            base.Configure();
            Mapper.CreateMap<BaseQuestion, ShortQuestionViewModel>();
        }
         
    }
}