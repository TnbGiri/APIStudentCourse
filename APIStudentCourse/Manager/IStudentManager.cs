using APIStudentCourse.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIStudentCourse.Manager
{
    public interface IStudentManager
    {
        Task<List<Course>> GetCourseList();
        Task<List<StudentDetails>> GetStudentist();
        Task<string> AddStudent(Student student);
        Task<string> AddCourse(StudentCourseInput studentCourse);
    }
}
