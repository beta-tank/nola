using System.Collections.Generic;
using System.Linq;
using Data.Repository;
using Nola.Core.Data;
using Nola.Core.Models.Education;

namespace Nola.Service.Services
{
    public interface ISubjectService : IService
    {
        Subject GetSubject(int id);
        IEnumerable<Subject> GetSubjects(IEnumerable<int> ids);
        Subject GetSubject(string name);
        IEnumerable<Subject> GetAll();
    }

    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public SubjectService(ISubjectRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }

        public Subject GetSubject(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Subject> GetSubjects(IEnumerable<int> ids)
        {
            return ids.Select(id => repository.GetById(id)).Where(s => s != null);
        }

        public Subject GetSubject(string name)
        {
            return repository.Get(s => s.Name == name);
        }

        public IEnumerable<Subject> GetAll()
        {
            return repository.GetAll();
        }
    }
}