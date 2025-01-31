using HundFit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Data.Configuration;

public static class ModelBuilderConfigurations
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingExercises>()
            .HasKey(te => new { te.TrainingId, te.ExerciseId });

        modelBuilder.Entity<TrainingExercises>()
            .HasOne(te => te.Training)
            .WithMany()
            .HasForeignKey(te => te.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TrainingExercises>()
            .HasOne(te => te.Exercise)
            .WithMany()
            .HasForeignKey(te => te.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Plan)
            .WithMany()
            .HasForeignKey(s => s.PlanId)
            .OnDelete(DeleteBehavior.SetNull);

        /*modelBuilder.Entity<Student>()
            .HasOne(s => s.Training)
            .WithMany()
            .HasForeignKey(s => s.TrainingId)
            .OnDelete(DeleteBehavior.SetNull);*/
        
        /*modelBuilder.Entity<Student>()
            .HasOne(s => s.Training)
            .WithOne(t => t.Instructor)
            .HasForeignKey<Training>(t => t.StudentId)
            .OnDelete(DeleteBehavior.NoAction);*/

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Instructor)
            .WithMany()
            .HasForeignKey(s => s.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentStats>()
            .HasOne(ss => ss.Student)
            .WithMany()
            .HasForeignKey(ss => ss.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentStats>()
            .HasOne(ss => ss.Instructor)
            .WithMany()
            .HasForeignKey(ss => ss.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}