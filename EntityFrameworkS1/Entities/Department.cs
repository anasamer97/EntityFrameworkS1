using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkS1.Entities
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Instructor Ins_ID { get; set; }
		public DateTime HiringDate { get; set; }
		public ICollection<Student> StudentID { get; set; }
		public ICollection<Instructor> Instructors { get; set; }

	}
}
