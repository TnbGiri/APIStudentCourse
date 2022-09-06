using System.Collections.Generic;

namespace APIStudentCourse.Models
{
    public class StudentCourseInput
    {
        public int StudentId { get; set; }
        public List<int> CourseList { get; set;}
    }
}
