using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkS1.Entities
{
	public class CourseInstructor
	{
		public int InstructorID { get; set; }
		public int CourseID { get; set; }
		public int Evaluate {  get; set; }

		public Instructor Instructor { get; set; }
		public Course Course { get; set; }
		public ICollection<Course> Courses { get; set; }
	}
}
