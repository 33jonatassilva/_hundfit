using HundFit.Models;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<PhysicalAssessment> PhysicalAssessments { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Training> Trainings { get; set; }
    
    public DbSet<TrainingExercises> TrainingExercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Exercise>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Exercise>()
            .HasMany(e => e.TrainingExercises)
            .WithOne(te => te.Exercise)
            .HasForeignKey(te => te.ExerciseId);

        
        modelBuilder.Entity<Instructor>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<Instructor>()
            .HasMany(i => i.Trainings)
            .WithOne(t => t.Instructor)
            .HasForeignKey(t => t.InstructorId);

        
        modelBuilder.Entity<PhysicalAssessment>()
            .HasKey(pa => pa.Id);

        modelBuilder.Entity<PhysicalAssessment>()
            .HasOne(pa => pa.Student)
            .WithMany()
            .HasForeignKey(pa => pa.StudentId);

        modelBuilder.Entity<PhysicalAssessment>()
            .HasOne(pa => pa.Instructor)
            .WithMany()
            .HasForeignKey(pa => pa.InstructorId);

        
        modelBuilder.Entity<Plan>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Plan>()
            .HasMany(p => p.Students)
            .WithOne(s => s.Plan)
            .HasForeignKey(s => s.PlanId);

        
        modelBuilder.Entity<Student>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Plan)
            .WithMany(p => p.Students)
            .HasForeignKey(s => s.PlanId);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Training)
            .WithMany()
            .HasForeignKey(s => s.TrainingId);

        
        modelBuilder.Entity<Training>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<Training>()
            .HasOne(t => t.Instructor)
            .WithMany(i => i.Trainings)
            .HasForeignKey(t => t.InstructorId);

        modelBuilder.Entity<Training>()
            .HasMany(t => t.Exercises)
            .WithOne()
            .HasForeignKey(e => e.TrainingId);

        
        modelBuilder.Entity<TrainingExercises>()
            .HasKey(te => new { te.TrainingId, te.ExerciseId });

        modelBuilder.Entity<TrainingExercises>()
            .HasOne(te => te.Training)
            .WithMany()
            .HasForeignKey(te => te.TrainingId);

        modelBuilder.Entity<TrainingExercises>()
            .HasOne(te => te.Exercise)
            .WithMany(e => e.TrainingExercises)
            .HasForeignKey(te => te.ExerciseId);
    }
}