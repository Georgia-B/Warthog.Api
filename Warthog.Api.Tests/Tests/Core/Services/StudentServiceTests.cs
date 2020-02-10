using System.Collections.Generic;
using System.Linq;
using Warthog.Api.Core.Repositories.Students;
using Warthog.Api.Core.Services.Students;
using Xunit;
using Moq;

namespace Warthog.Api.Tests.Tests.Core.Services
{
    public class StudentServiceTests
    {
        [Fact]
        public void StudentService_GetStudents_Success()
        {
            var list = new List<Student>();
            list.Add(new Student()
            {
                Id = "1234",
                FirstName = "Hermione",
                LastName = "Granger",
                Gpa = 9,
                House = "Gryffindor"
            });
            list.Add(new Student()
            {
                Id = "4567",
                FirstName = "Harry",
                LastName = "Potter",
                Gpa = 5,
                House = "Gryffindor"
            });
            var studentRepository = new Mock<IStudentRepository>();
            studentRepository.Setup(d => d.GetStudents(It.IsAny<int>())).Returns(list);


            var studentService = new StudentService(studentRepository.Object);
            var students = studentService.GetStudents(1);
            Assert.Equal(2, students.ToList().Count);
        }

        [Fact]
        public void StudentService_GetStudent_Success()
        {
            var student = new Student()
            {
                Id = "1234",
                FirstName = "Hermione",
                LastName = "Granger",
                Gpa = 9,
                House = "Gryffindor"
            };
            
            var studentRepository = new Mock<IStudentRepository>();
            studentRepository.Setup(d => d.GetStudent(It.IsAny<string>())).Returns(student);


            var studentService = new StudentService(studentRepository.Object);
            var actualStudent = studentService.GetStudent("1234");
            Assert.NotNull(actualStudent);
        }
    }
}
