using System;
using Authorization.Models;

namespace Authorization.Interfaces
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);

        public void Delete(int id);

        public void Register(int sturdentId, int courseId);
    }
}

