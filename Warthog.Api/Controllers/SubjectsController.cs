using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warthog.Api.Core.Services.Subjects;
using Warthog.Api.Models;

namespace Warthog.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// Returns photos that match the passed.
        /// </summary>
        /// <returns>The photos that match the passed params</returns>
        [ProducesResponseType(200)]
        [HttpGet]
        [Route("subjects")]
        public ActionResult<Subject> GetSubjects()
        {
            try
            {
                var subjects = _subjectService.GetSubjects();

                return Ok(subjects);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        /// <summary>
        /// Returns a single app summary with the passed `slug`.
        /// </summary>
        /// <returns>The app summary that match the passed params</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("subjects/{id}")]
        public ActionResult<Subject> GetSubject(string id)
        {
            try
            {
                var subject = _subjectService.GetSubject(id);

                if (subject == null)
                {
                    return NotFound();
                }

                return Ok(subject);
            }
            catch
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}
