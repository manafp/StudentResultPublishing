using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentResultPublishing.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    RegisterNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMark = table.Column<double>(nullable: false),
                    Grade = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    StudentDetailsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentResult_StudentDetails_StudentDetailsid",
                        column: x => x.StudentDetailsid,
                        principalTable: "StudentDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentResult_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_StudentDetailsid",
                table: "StudentResult",
                column: "StudentDetailsid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResult_SubjectId",
                table: "StudentResult",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentResult");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
