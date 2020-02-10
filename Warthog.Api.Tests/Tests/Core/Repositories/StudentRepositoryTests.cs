using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Warthog.Api.Models;
using Warthog.Api.Core.Repositories.Students;
using Xunit;
using Moq;
using Serilog;

namespace Warthog.Api.Tests.Core.Repositories
{
    public class StudentRepositoryTests
    {
        private readonly string ConnectionString = "mongodb://127.0.0.1:27017";
        private readonly string DatabaseName = "WarthogDB";
        private readonly string StudentsCollectionName = "Students";

        [Fact]
        public void StudentRepository_GetStudents_Success()
        {
            var warthogDatabaseSettings = new WarthogDatabaseSettings()
            { 
                ConnectionString = ConnectionString,
                DatabaseName = DatabaseName,
                StudentsCollectionName = StudentsCollectionName
            };
            var logger = new Mock<ILogger>();

            var studentRepository = new StudentRepository(warthogDatabaseSettings, logger.Object);
            var students = studentRepository.GetStudents(20);
            Assert.Equal(20, students.ToList().Count);
        }

        [Fact]
        public void StudentRepository_GetStudents_SuccessWhenDBFails()
        {
            var warthogDatabaseSettings = new WarthogDatabaseSettings()
            {
                ConnectionString = "mongodb://notgonnaconnect",
                DatabaseName = DatabaseName,
                StudentsCollectionName = StudentsCollectionName
            };
            var logger = new Mock<ILogger>();

            var studentRepository = new StudentRepository(warthogDatabaseSettings, logger.Object);
            var students = studentRepository.GetStudents(20);
            Assert.Equal(20, students.ToList().Count);
        }
    }
}