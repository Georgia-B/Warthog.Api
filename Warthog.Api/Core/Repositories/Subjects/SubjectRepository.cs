using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Warthog.Api.Models;


namespace Warthog.Api.Core.Repositories.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private IList<Subject> list = new List<Subject>();

        public SubjectRepository()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var jsonString = File.ReadAllText("core/repositories/subjects/subjects.json");
            list = JsonSerializer.Deserialize<IList<Subject>>(jsonString, options);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return list;
        }

        public Subject GetSubject(Guid subjectId)
        {
            return list.SingleOrDefault(subject => subject.Id == subjectId);
        }
    }
}
