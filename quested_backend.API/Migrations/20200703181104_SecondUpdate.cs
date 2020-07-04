using Microsoft.EntityFrameworkCore.Migrations;

namespace quested_backend.Migrations
{
    public partial class SecondUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_course_instance_course1",
                table: "course");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "course",
                newName: "season_id");

            migrationBuilder.RenameIndex(
                name: "fk_course_instance_course1_idx",
                table: "course",
                newName: "fk_course_instance_season1_idx");

            migrationBuilder.AlterColumn<int>(
                name: "achieved_points",
                table: "pupil_in_course_answers_question",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_course_instance_season1",
                table: "course",
                column: "season_id",
                principalTable: "season",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_course_instance_season1",
                table: "course");
            
            migrationBuilder.RenameColumn(
                name: "season_id",
                table: "course",
                newName: "course_id");
            
            migrationBuilder.RenameIndex(
                name: "fk_course_instance_season1_idx",
                table: "course",
                newName: "fk_course_instance_course1_idx");
            
            migrationBuilder.AlterColumn<string>(
                name: "achieved_points",
                table: "pupil_in_course_answers_question",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");
            
            migrationBuilder.AddForeignKey(
                name: "fk_course_instance_course1",
                table: "course",
                column: "course_id",
                principalTable: "season",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
