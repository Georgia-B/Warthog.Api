using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warthog.Api.Core.Services.Students;

namespace Warthog.Api.Controllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        /// <summary>
        /// Returns a list of students.
        /// </summary>
        /// <returns>The list of students</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("students")]
        public ActionResult<IList<Student>> GetStudents([FromQuery(Name = "count")] int count = 20)
        {
            try
            {
                var students = _studentService.GetStudents(count);

                if (students == null)
                {
                    return NotFound();
                }

                return Ok(students);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        /// <summary>
        /// Returns a single student.
        /// </summary>
        /// <returns>The student summary that match the passed params</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("students/{id}")]
        public ActionResult<Student> GetStudent(string id)
        {
            try
            {
                var student = _studentService.GetStudent(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}
