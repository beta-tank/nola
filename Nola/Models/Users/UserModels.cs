﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nola.Core;

namespace Nola.Models
{
    public class BaseUser
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IImage AvatarImage { get; set; }
        public School School { get; set; }
    }

    public class StudentUser : BaseUser
    {
        public TeachingType TeachingType { get; set; }
        public int Grade { get; set; }
    }

    public class TeacherUser : BaseUser
    {
        public bool IsConfirmed { get; set; }
    }
}