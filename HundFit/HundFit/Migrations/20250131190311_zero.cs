using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HundFit.Migrations
{
    /// <inheritdoc />
    public partial class zero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Instructors_InstructorId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Trainings_TrainingId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "TrainingExercises");

            migrationBuilder.CreateTable(
                name: "TrainingExercise",
                columns: table => new
                {
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExercise", x => new { x.TrainingId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_TrainingExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingExercise_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercise_ExerciseId",
                table: "TrainingExercise",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Instructors_InstructorId",
                table: "Students",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Trainings_TrainingId",
                table: "Students",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Instructors_InstructorId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Trainings_TrainingId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "TrainingExercise");

            migrationBuilder.CreateTable(
                name: "TrainingExercises",
                columns: table => new
                {
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExercises", x => new { x.TrainingId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_TrainingExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingExercises_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_ExerciseId",
                table: "TrainingExercises",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Instructors_InstructorId",
                table: "Students",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Trainings_TrainingId",
                table: "Students",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id");
        }
    }
}
