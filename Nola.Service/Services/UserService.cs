using Data.Repository;
using Nola.Core.Models.Users;
using Nola.Data;

namespace Nola.Service.Services
{
    public interface IUserService : IService
    {
        ApplicationUser GetUser(int id);
        ApplicationUser GetUser(string id);
        BaseUser GetProfile(int id);
        BaseUser GetProfile(string id);
        void AddProfile(BaseUser profile);
        void DeleteUser(ApplicationUser user);


    }
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IBaseUserRepository profileRepository;
        private readonly IStudentUserRepository studentRepository;
        private readonly ITeacherUserRepository teacherRepository;
        private readonly IUnitOfWork unitOfWork;


        public UserService(IUserRepository userRepository, IBaseUserRepository profileRepository, IStudentUserRepository studentRepository, ITeacherUserRepository teacherRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.profileRepository = profileRepository;
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.unitOfWork = unitOfWork;
        }

        public ApplicationUser GetUser(int id)
        {
            return userRepository.GetById(id);
        }

        public BaseUser GetProfile(int id)
        {
            return profileRepository.GetById(id);
        }

        public BaseUser GetProfile(string id)
        {
            int idInt = 0;
            return int.TryParse(id, out idInt) ? profileRepository.GetById(idInt) : null;
        }

        public void AddProfile(BaseUser profile)
        {
            profileRepository.Add(profile);
        }

        public ApplicationUser GetUser(string id)
        {
            int idInt = 0;
            return int.TryParse(id, out idInt) ? userRepository.GetById(idInt) : null;
        }

        public void DeleteUser(ApplicationUser user)
        {
            profileRepository.Delete(p => p.Id == user.Id);
            userRepository.Delete(p => p.Id == user.Id);           
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }
    }
}