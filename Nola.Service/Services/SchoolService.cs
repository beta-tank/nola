using System.Collections.Generic;
using System.Linq;
using Data.Repository;
using Nola.Core.Data;
using Nola.Core.Models.Education;

namespace Nola.Service.Services
{
    public interface ISchoolService : IService
    {
        School GetSchool(int id);
        School GetSchool(string name);
        IEnumerable<School> GetAll();
    }

    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public SchoolService(ISchoolRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }

        public School GetSchool(int id)
        {
            return repository.GetById(id);
        }

        public School GetSchool(string name)
        {
            return repository.Get(s => s.Name == name);
        }

        public IEnumerable<School> GetAll()
        {
            return repository.GetAll();
        }
    }
}