using HundFit.Models;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Data.Configuration;

public static class ModelBuilderConfigurations
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
// Configuração para TrainingExercises (muitos-para-muitos entre Training e Exercise)
        modelBuilder.Entity<TrainingExercises>()
            .HasKey(te => new { te.TrainingId, te.ExerciseId }); // Chave composta

        modelBuilder.Entity<TrainingExercises>()
            .HasOne(te => te.Training)
            .WithMany(t => t.TrainingExercises)
            .HasForeignKey(te => te.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TrainingExercises>()
            .HasOne(te => te.Exercise)
            .WithMany(e => e.TrainingExercises)
            .HasForeignKey(te => te.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

            // Configuração para Training e Student (um-para-um opcional)
            modelBuilder.Entity<Training>()
                .HasOne(t => t.Student)
                .WithOne(s => s.Training)
                .HasForeignKey<Student>(s => s.TrainingId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configuração para Student e Plan (um-para-muitos)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Plan)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração para PhysicalAssessment (avaliação física com instrutor e aluno)
            modelBuilder.Entity<PhysicalAssessment>()
                .HasOne(pa => pa.Student)
                .WithMany()
                .HasForeignKey(pa => pa.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PhysicalAssessment>()
                .HasOne(pa => pa.Instructor)
                .WithMany()
                .HasForeignKey(pa => pa.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}