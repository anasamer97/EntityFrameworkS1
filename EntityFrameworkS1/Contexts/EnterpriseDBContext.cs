using EntityFrameworkS1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkS1.Contexts
{
	internal class EnterpriseDBContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=EntityOne;Trusted_Connection=true;TrustServerCertificate=true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// StudentCourse configurations
			modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentID, sc.CourseID });
			modelBuilder.Entity<StudentCourse>().HasOne(s => s.Student).WithMany(sc => sc.StudentCourses);

			// Course configurations
			modelBuilder.Entity<Topic>()
			.HasMany(t => t.Courses)  // One topic has many courses
			.WithOne(c => c.Top_ID);   // Each course has one topic


			// Deparment configurations + Student configuration
			modelBuilder.Entity<Student>().HasOne(s => s.Dep_Id)
											.WithMany(s => s.StudentID)	
											.OnDelete(DeleteBehavior.Cascade);


			modelBuilder.Entity<CourseInstructor>().HasKey(CI => new { CI.InstructorID, CI.CourseID });
			modelBuilder.Entity<CourseInstructor>()
				.HasOne(ci => ci.Instructor) // Each CourseInstructor has one Instructor
				.WithMany(i => i.CourseInstructors); // Each Instructor can teach many courses (via CourseInstructor)
													 // Foreign key to Instructor in CourseInstructor table

			modelBuilder.Entity<CourseInstructor>()
				.HasOne(ci => ci.Course) // Each CourseInstructor has one Course
				.WithOne(c => c.CourseInstructor); // Each Course is taught by only one Instructor via CourseInstructor
				 // Foreign key to Course in CourseInstructor table


			modelBuilder.Entity<Department>().HasMany(d => d.Instructors).WithOne(i => i.Dep_Id);






		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<Instructor> Instrctors { get; set; }
		public DbSet<CourseInstructor> InstructorsCourses { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }

	}
}
