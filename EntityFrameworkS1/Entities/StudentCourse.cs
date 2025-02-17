using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkS1.Entities
{
	public class StudentCourse
	{
		public int StudentID { get; set; }
		public int CourseID { get; set; }
		public float Grade { get; set; }

		public Student Student { get; set; }
		public Course Course { get; set; }
		public ICollection<StudentCourse> StudentCourses { get; set; }

	}
}
