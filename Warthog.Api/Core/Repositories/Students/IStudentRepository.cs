using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warthog.Api.Core.Repositories.Students
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudents(int count);
        public Student GetStudent(string studentId);
    }
}
