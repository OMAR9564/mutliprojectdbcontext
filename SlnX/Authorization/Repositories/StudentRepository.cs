using System;
using Authorization.Data;
using Authorization.Interfaces;
using Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _myDbConnection;
        public StudentRepository(ApplicationDbContext myDbContext)
        {
            _myDbConnection = myDbContext;
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from stdsObj in _myDbConnection.Students
                                          select stdsObj).ToList();
                return students;

            }
            catch (Exception ex)
            {
                return null;

            }

        }
        public void Create(Student student)
        {
            _myDbConnection.Students.Add(student);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = (from stdObj in _myDbConnection.Students
                               where stdObj.StudentId == id
                               select stdObj).FirstOrDefault();

            _myDbConnection.Students.Remove(student);
            _myDbConnection.SaveChanges();
        }

        public void Register(int studentId, int courseId)
        {
            StudentCourse obj = new StudentCourse();
            obj.CourseId = courseId;
            obj.StudentId = studentId;

            _myDbConnection.StudentCourses.Add(obj);

            _myDbConnection.SaveChanges();
        }
    }
}

