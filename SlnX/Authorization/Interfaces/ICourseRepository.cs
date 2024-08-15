﻿using System;
using Authorization.Models;

namespace Authorization.Interfaces
{
	public interface ICourseRepository
	{
        public List<Course> GetAllCourses();

        public void Create(Course course);

        public void Delete(int id);
    }
}

