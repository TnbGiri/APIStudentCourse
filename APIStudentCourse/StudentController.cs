using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APIStudentCourse.Manager;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using APIStudentCourse.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIStudentCourse
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager studentManager;    

        public StudentController(IStudentManager _studentManager)
        {
            studentManager = _studentManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseList() 
        {
            try
            {
                var result = await studentManager.GetCourseList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// get student detail list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStudentist()
        {
            try
            {
                var result = await studentManager.GetStudentist();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        
        
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            try
            {
                var result = await studentManager.AddStudent(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        
        
        [HttpPost]
        public async Task<IActionResult> AddCourse(StudentCourseInput studentCourse)
        {
            try
            {
                var result = await studentManager.AddCourse(studentCourse);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
