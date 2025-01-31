using HundFit.Data.Configuration;
using HundFit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<StudentStats> StudentStats { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Training> Trainings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
    }

}