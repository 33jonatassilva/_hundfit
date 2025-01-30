using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HundFit.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Exercises_ExerciseId1",
                table: "TrainingExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainingExercises_ExerciseId1",
                table: "TrainingExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainingExercises_TrainingId",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId1",
                table: "TrainingExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises",
                columns: new[] { "TrainingId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises");

            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseId1",
                table: "TrainingExercises",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_ExerciseId1",
                table: "TrainingExercises",
                column: "ExerciseId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_TrainingId",
                table: "TrainingExercises",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Exercises_ExerciseId1",
                table: "TrainingExercises",
                column: "ExerciseId1",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Instructors_InstructorId",
                table: "Trainings",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
