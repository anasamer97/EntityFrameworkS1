using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkS1.Entities
{
	public class Instructor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Bonus { get; set; }
		public int Salary { get; set; }
		public string Address { get; set; }
		public int HourRate { get; set; }
		public Department Dep_Id { get; set; }
		//public int DepartmentID { get; set; }
		public ICollection<CourseInstructor> CourseInstructors { get; set; }




	}
}
