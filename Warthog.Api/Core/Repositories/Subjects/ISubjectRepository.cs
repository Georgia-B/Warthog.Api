using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warthog.Api.Models;

namespace Warthog.Api.Core.Repositories.Subjects
{
    public interface ISubjectRepository
    {
        public IEnumerable<Subject> GetSubjects();
        public Subject GetSubject(Guid subjectId);
    }
}
