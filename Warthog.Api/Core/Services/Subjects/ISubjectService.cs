using System.Collections.Generic;
using Warthog.Api.Models;

namespace Warthog.Api.Core.Services.Subjects
{
    public interface ISubjectService
    {
        public IEnumerable<Subject> GetSubjects();
        public Subject GetSubject(string id);
    }
}
