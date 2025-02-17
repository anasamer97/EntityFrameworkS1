using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkS1.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Dep_IdId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Dep_Id",
                table: "Instrctors");

            migrationBuilder.RenameColumn(
                name: "Dep_IdId",
                table: "Students",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Dep_IdId",
                table: "Students",
                newName: "IX_Students_DepartmentID");

            migrationBuilder.RenameColumn(
                name: "Ins_ID",
                table: "Departments",
                newName: "Ins_IDId");

            migrationBuilder.RenameColumn(
                name: "Top_ID",
                table: "Courses",
                newName: "Top_IDId");

            migrationBuilder.AddColumn<int>(
                name: "Dep_IdId",
                table: "Instrctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseInstructorCourseID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseInstructorInstructorID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstructorsCourses",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Evaluate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorsCourses", x => new { x.InstructorID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_InstructorsCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorsCourses_Instrctors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instrctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    StudentCourseCourseID = table.Column<int>(type: "int", nullable: true),
                    StudentCourseStudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_StudentCourses_StudentCourseStudentID_StudentCourseCourseID",
                        columns: x => new { x.StudentCourseStudentID, x.StudentCourseCourseID },
                        principalTable: "StudentCourses",
                        principalColumns: new[] { "StudentID", "CourseID" });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrctors_Dep_IdId",
                table: "Instrctors",
                column: "Dep_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Ins_IDId",
                table: "Departments",
                column: "Ins_IDId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseInstructorInstructorID_CourseInstructorCourseID",
                table: "Courses",
                columns: new[] { "CourseInstructorInstructorID", "CourseInstructorCourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Top_IDId",
                table: "Courses",
                column: "Top_IDId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorsCourses_CourseID",
                table: "InstructorsCourses",
                column: "CourseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentCourseStudentID_StudentCourseCourseID",
                table: "StudentCourses",
                columns: new[] { "StudentCourseStudentID", "StudentCourseCourseID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_InstructorsCourses_CourseInstructorInstructorID_CourseInstructorCourseID",
                table: "Courses",
                columns: new[] { "CourseInstructorInstructorID", "CourseInstructorCourseID" },
                principalTable: "InstructorsCourses",
                principalColumns: new[] { "InstructorID", "CourseID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Topics_Top_IDId",
                table: "Courses",
                column: "Top_IDId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instrctors_Ins_IDId",
                table: "Departments",
                column: "Ins_IDId",
                principalTable: "Instrctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instrctors_Departments_Dep_IdId",
                table: "Instrctors",
                column: "Dep_IdId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_InstructorsCourses_CourseInstructorInstructorID_CourseInstructorCourseID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Topics_Top_IDId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instrctors_Ins_IDId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instrctors_Departments_Dep_IdId",
                table: "Instrctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "InstructorsCourses");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_Instrctors_Dep_IdId",
                table: "Instrctors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Ins_IDId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseInstructorInstructorID_CourseInstructorCourseID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Top_IDId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Dep_IdId",
                table: "Instrctors");

            migrationBuilder.DropColumn(
                name: "CourseInstructorCourseID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseInstructorInstructorID",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Students",
                newName: "Dep_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentID",
                table: "Students",
                newName: "IX_Students_Dep_IdId");

            migrationBuilder.RenameColumn(
                name: "Ins_IDId",
                table: "Departments",
                newName: "Ins_ID");

            migrationBuilder.RenameColumn(
                name: "Top_IDId",
                table: "Courses",
                newName: "Top_ID");

            migrationBuilder.AddColumn<int>(
                name: "Dep_Id",
                table: "Instrctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Dep_IdId",
                table: "Students",
                column: "Dep_IdId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
