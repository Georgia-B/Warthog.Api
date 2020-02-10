using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warthog.Api.Core.Services.Students;
using Serilog;

namespace Warthog.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger logger, IStudentService studentService)
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

                _logger.Information($"StudentController - Successfully fetched {count} students");
                return Ok(students);
            }
            catch
            {
                _logger.Error($"StudentController - Failed to fetch {count} students");
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
                    _logger.Error($"StudentController - Failed to fetch student {id}");
                    return NotFound();
                }

                _logger.Information($"StudentController - Successfully fetched student {id}");
                return Ok(student);
            }
            catch
            {
                _logger.Error($"StudentController - Failed to fetch student {id}");
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}
