using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using MongoDB.Driver;
using Warthog.Api.Models;

namespace Warthog.Api.Core.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private Data list = new Data();
        private readonly IMongoCollection<Student> _studentCollection;

        public StudentRepository(IWarthogDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _studentCollection = database.GetCollection<Student>(settings.StudentsCollectionName);
            
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var jsonString = File.ReadAllText("core/repositories/students/students.json");
            list = JsonSerializer.Deserialize<Data>(jsonString, options);
        }

        public IEnumerable<Student> GetStudents(int count)
        {
            try
            {
                var students = _studentCollection.Find<Student>(student => true).ToList();
                if (count < students.Count)
                {
                    return students.GetRange(0, count);
                }
                var remaining = count - students.Count;
                var randomStudents = GetRandomStudents(remaining);
                students.AddRange(randomStudents);
                return students;
            }
            catch (Exception e)
            {
                throw new Exception("StudentRepository - Failed to fetch list of students", e);
            }
        }

        public Student GetStudent(string studentId)
        {
            return _studentCollection.Find<Student>(student => student.Id == studentId).FirstOrDefault();
        }

        private Student GetRandomStudent()
        {
            var studentId = Guid.NewGuid().ToString();
            Random rand = new Random();
            int firstNameIndex = rand.Next(list.FirstNames.Count);
            int lastNameIndex = rand.Next(list.LastNames.Count);
            int gpaIndex = rand.Next(list.Gpas.Count);
            int houseIndex = rand.Next(list.Houses.Count);
            return new Student()
            {
                Id = studentId,
                FirstName = list.FirstNames[firstNameIndex],
                LastName = list.LastNames[lastNameIndex],
                Gpa = list.Gpas[gpaIndex],
                House = list.Houses[houseIndex]
            };
        }

        private IList<Student> GetRandomStudents(int count)
        {
            List<Student> list = new List<Student>();
            for(var i = 0; i < count; i++)
            {
                list.Add(GetRandomStudent());
            }
            return list;
        }
    }
}
