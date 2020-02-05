using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warthog.Api.Core.Services.Students
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetStudents(int count);
        public Student GetStudent(string id);
    }
}
