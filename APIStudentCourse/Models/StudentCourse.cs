using System;
using System.Collections.Generic;

#nullable disable

namespace APIStudentCourse.Models
{
    public partial class StudentCourse
    {
        public int AutoId { get; set; }
        public int SudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Sudent { get; set; }
    }
}
