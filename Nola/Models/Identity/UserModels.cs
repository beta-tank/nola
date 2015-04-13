using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nola.Models
{
    public interface IUserInfo {}

    public class BaseUserInfo : IUserInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IImage AvatarImage { get; set; }
    }

    public class StudentUserInfo : BaseUserInfo
    {
        public TeachingType TeachingType { get; set; }
        public int Grade { get; set; }
    }

    public class TeachertUserInfo : BaseUserInfo
    {
        public bool IsConfirmed { get; set; }
    }


    public enum TeachingType
    {
        First = 1,
        Second
    }
    
    

}