using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Warthog.Api
{
    public class Student
    {
        public Student() { }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gpa { get; set; }
        public string House { get; set; }
    }
}
