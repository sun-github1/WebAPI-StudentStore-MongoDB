using MongoDB.Driver;
using StudentStore.Core;
using StudentStore.Core.Models;
using StudentStore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentStore.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IStudentStoreDatabaseSettings settings, 
            IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(
                settings.StudentStoreCollectionName);
        }
        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Student> Get()
        {
            return _students.Find<Student>(student=>true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find<Student>(student => student.Id==id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, Student student)
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }
    }
}
