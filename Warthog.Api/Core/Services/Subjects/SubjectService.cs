using System;
using System.Collections.Generic;
using Warthog.Api.Models;
using Warthog.Api.Core.Repositories.Subjects;

namespace Warthog.Api.Core.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _subjectRepository.GetSubjects();
        }

        public Subject GetSubject(string id)
        {
            var subjectId = Guid.Parse(id);
            return _subjectRepository.GetSubject(subjectId);
        }
    }
}
