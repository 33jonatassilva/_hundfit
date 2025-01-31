using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HundFit.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Students_StudentId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_StudentId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Trainings");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "Trainings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TrainingId",
                table: "Students",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Trainings_TrainingId",
                table: "Students",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Trainings_TrainingId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Students_TrainingId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "Trainings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Trainings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_StudentId",
                table: "Trainings",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Students_StudentId",
                table: "Trainings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
