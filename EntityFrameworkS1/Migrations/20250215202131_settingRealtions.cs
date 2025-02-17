using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkS1.Migrations
{
    /// <inheritdoc />
    public partial class settingRealtions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dep_Id",
                table: "Students",
                newName: "Dep_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dep_IdId",
                table: "Students",
                column: "Dep_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Dep_IdId",
                table: "Students",
                column: "Dep_IdId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Dep_IdId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Dep_IdId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Dep_IdId",
                table: "Students",
                newName: "Dep_Id");
        }
    }
}
