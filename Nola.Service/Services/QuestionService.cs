using System.Collections.Generic;
using Data.Repository;
using Nola.Core.Models.Question;
using Nola.Data;

namespace Nola.Service.Services
{
    public interface IQuestionService : IService
    {
        BaseQuestion GetQuestion(int id);
        void AddQuestion(BaseQuestion question);
        void UpdateQuestion(BaseQuestion question);
        void DeleteQuestion(BaseQuestion question);
        IEnumerable<BaseQuestion> GetAll();
    }

    public class QuestionService : IQuestionService
    {
        private readonly IBaseQuestionRepository questionRepository;
        private readonly IUnitOfWork unitOfWork;

        public QuestionService(IBaseQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            this.questionRepository = questionRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }

        public BaseQuestion GetQuestion(int id)
        {
            return questionRepository.GetById(id);
        }

        public void AddQuestion(BaseQuestion question)
        {
            questionRepository.Add(question);
        }

        public void UpdateQuestion(BaseQuestion question)
        {
            questionRepository.Update(question);
        }

        public void DeleteQuestion(BaseQuestion question)
        {
            questionRepository.Delete(question);
        }

        public IEnumerable<BaseQuestion> GetAll()
        {
            return questionRepository.GetAll();
        }
    }
}