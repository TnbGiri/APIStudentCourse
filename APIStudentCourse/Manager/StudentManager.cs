using APIStudentCourse.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace APIStudentCourse.Manager
{
    public class StudentManager : IStudentManager
    {
        private readonly dbStudentCourseContext studentCourseContext;
        public StudentManager(dbStudentCourseContext _dbStudentCourseContext)
        {
            studentCourseContext = _dbStudentCourseContext;
        }

        public async Task<string> AddCourse(StudentCourseInput studentCourse)
        {
            if (studentCourse.StudentId!=0 && studentCourse.CourseList!=null)
            {
                var list = new List<StudentCourse>();
                foreach (var course in studentCourse.CourseList)
                {
                    list.Add(new StudentCourse { SudentId = studentCourse.StudentId, CourseId = course });
                }
                studentCourseContext.StudentCourses.AddRange(list);
                await studentCourseContext.SaveChangesAsync();
            }
            return "Successfully Submitted";
        }

        public async Task<string> AddStudent(Student student)
        {
            if (student!=null && string.IsNullOrEmpty(student.Name))
            {
                studentCourseContext.Students.Add(student); 
                await studentCourseContext.SaveChangesAsync();
                return "Student added successfully";
            }
            else
            {
                return "Empty object";
            }
        }

        public async Task<List<Course>> GetCourseList()
        {
            var query = (from c in studentCourseContext.Courses
                         select new Course()
                         {
                             CourseId = c.CourseId,
                             CourseName = c.CourseName,

                         }).AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<List<StudentDetails>> GetStudentist()
        {
            var query = (from sc in studentCourseContext.StudentCourses
                          join s in studentCourseContext.Students on sc.SudentId equals s.StudentId
                          join c in studentCourseContext.Courses on sc.CourseId equals c.CourseId                         
                          select new 
                          {
                            Email= s.Email,
                            Phone=s.Phone,
                            Name=s.Name,
                            StudentId= s.StudentId,
                            CourseDetails= c.CourseName
                          }
                          ).AsQueryable();

            var result = await query.ToListAsync();

            return (from a in result
                    group a by new { a.Name,a.Phone,a.Email,a.StudentId}
                    into gp
                    select new StudentDetails { 
                        StudentId = (int)gp.Key.StudentId,
                        Email= gp.Key.Email,
                        Phone = gp.Key.Phone,
                        Name = gp.Key.Name,
                        CourseDetails= string.Join(",",gp.Select(x=>x.CourseDetails))
                    }).ToList();
                  
        }


    }
}
