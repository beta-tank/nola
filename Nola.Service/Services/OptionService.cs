using System.Collections.Generic;
using Data.Repository;
using Nola.Core.Models.Question;
using Nola.Data;

namespace Nola.Service.Services
{
    public interface IOptionService : IService
    {
        BaseOption GetOption(int id);
        void AddOption(BaseOption option);
        void UpdateOption(BaseOption option);
        void DeleteOption(BaseOption option);
        IEnumerable<BaseOption> GetAll();
    }

    public class OptionService : IOptionService
    {
        private readonly IBaseOptionRepository optionRepository;
        private readonly IUnitOfWork unitOfWork;

        public OptionService(IBaseOptionRepository optionRepository, IUnitOfWork unitOfWork)
        {
            this.optionRepository = optionRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Commit()
        {
           unitOfWork.Commit();
        }

        public BaseOption GetOption(int id)
        {
            return optionRepository.GetById(id);
        }

        public void AddOption(BaseOption option)
        {
            optionRepository.Add(option);
        }

        public void UpdateOption(BaseOption option)
        {
            optionRepository.Update(option);
        }

        public void DeleteOption(BaseOption option)
        {
            optionRepository.Delete(option);
        }

        public IEnumerable<BaseOption> GetAll()
        {
            return optionRepository.GetAll();
        }
    }
}