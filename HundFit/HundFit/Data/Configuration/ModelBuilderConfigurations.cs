using HundFit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Data.Configuration;

public static class ModelBuilderConfigurations
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
       
        // Relacionamento um para muitos - Instrutor pode ter vários alunos
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Instructor)
            .WithMany(i => i.Students)
            .HasForeignKey(s => s.InstructorId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relacionamento um para muitos - Plano pode ter vários alunos
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Plan)
            .WithMany(p => p.Students)
            .HasForeignKey(s => s.PlanId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relacionamento um para muitos - Treino pode ter vários alunos
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Training)
            .WithMany(t => t.Students)
            .HasForeignKey(s => s.TrainingId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relacionamento muitos para muitos - Treinos podem ter vários exercícios
        modelBuilder.Entity<Training>()
            .HasMany(t => t.Exercises)
            .WithMany(e => e.Training)
            .UsingEntity<Dictionary<string, object>>(
                "TrainingExercise",
                j => j.HasOne<Exercise>().WithMany().HasForeignKey("ExerciseId"),
                j => j.HasOne<Training>().WithMany().HasForeignKey("TrainingId"),
                j => j.HasKey("TrainingId", "ExerciseId"));

        // Relacionamento um para muitos - Estatísticas de alunos
        modelBuilder.Entity<StudentStats>()
            .HasOne(ss => ss.Student)
            .WithMany(s => s.StudentStats)
            .HasForeignKey(ss => ss.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentStats>()
            .HasOne(ss => ss.Instructor)
            .WithMany()
            .HasForeignKey(ss => ss.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}