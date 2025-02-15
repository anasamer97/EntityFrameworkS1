using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkS1.Entities
{
	public class Course
	{
		public int Id { get; set; }
		public int Duration { get; set; }
		public string Name { get; set; }
		public string Descripition { get; set; }
		public int Top_ID { get; set; }
	}
}
