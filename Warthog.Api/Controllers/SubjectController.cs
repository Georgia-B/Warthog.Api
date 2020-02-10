using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warthog.Api.Core.Services.Subjects;
using Warthog.Api.Models;
using Serilog;

namespace Warthog.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ILogger _logger;

        public SubjectController(ISubjectService subjectService, ILogger logger)
        {
            _subjectService = subjectService;
            _logger = logger;
        }

        /// <summary>
        /// Returns a list of all subjects.
        /// </summary>
        /// <returns>A subject list</returns>
        [ProducesResponseType(200)]
        [HttpGet]
        [Route("subjects")]
        public ActionResult<Subject> GetSubjects()
        {
            try
            {
                var subjects = _subjectService.GetSubjects();
                _logger.Information($"SubjectController - Successfully fetched list of subjects");
                return Ok(subjects);
            }
            catch
            {
                _logger.Error("SubjectController - Failed to fetch list of subjects");
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        /// <summary>
        /// Returns a single subject.
        /// </summary>
        /// <returns>The subject that matches the passed params</returns>
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
                _logger.Information($"SubjectController - Successfully fetched subject with id: {id}");
                return Ok(subject);
            }
            catch
            {
                _logger.Error($"SubjectController - Failed to fetch subject with id: {id}");
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}
