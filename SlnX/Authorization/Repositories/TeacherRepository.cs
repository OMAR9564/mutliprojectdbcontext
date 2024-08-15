using System;
using Authorization.Data;
using Authorization.Interfaces;
using Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _myDbContext;

        public TeacherRepository(ApplicationDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Create(Teacher teacher)
        {
            _myDbContext.Teachers.Add(teacher);
            _myDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = (from teacherObj in _myDbContext.Teachers
                               where teacherObj.TeacherId == id
                               select teacherObj).FirstOrDefault();
            _myDbContext.Teachers.Remove(teacher);
            _myDbContext.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = (from teacherObj in _myDbContext.Teachers
                                      select teacherObj).ToList();

            return teachers;
        }
    }
}

