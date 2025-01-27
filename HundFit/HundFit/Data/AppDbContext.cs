using HundFit.Models;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Data;

public class AppDbContext : DbContext
{
    
    
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<PhysicalAssessment> PhysicalAssessments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
        
        
}