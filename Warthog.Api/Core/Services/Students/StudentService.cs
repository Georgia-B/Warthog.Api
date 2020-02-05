using System.Collections.Generic;
using Warthog.Api.Core.Repositories.Students;

namespace Warthog.Api.Core.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IEnumerable<Student> GetStudents(int count)
        {
            return _studentRepository.GetStudents(count);
        }

        public Student GetStudent(string id)
        {
            return _studentRepository.GetStudent(id);
        }
    }
}
