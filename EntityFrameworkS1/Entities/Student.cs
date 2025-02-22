﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkS1.Entities
{
	public class Student
	{
		public int Id { get; set; }
		public string FName { get; set; }
		public string LName { get; set; }
		public string Address { get; set; }
		public int Age { get; set; }
		public int DepartmentID { get; set; }
		public Department Dep_Id { get; set; }

		public ICollection<StudentCourse> StudentCourses { get; set; }
	}
}
