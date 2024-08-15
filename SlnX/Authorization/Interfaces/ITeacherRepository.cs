using System;
using Authorization.Models;

namespace Authorization.Interfaces
{
	public interface ITeacherRepository
	{
        public List<Teacher> GetAllTeachers();

        public void Create(Teacher teacher);

        public void Delete(int id);
    }
}

