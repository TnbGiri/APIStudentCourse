using System;
using System.Collections.Generic;

#nullable disable

namespace APIStudentCourse.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
