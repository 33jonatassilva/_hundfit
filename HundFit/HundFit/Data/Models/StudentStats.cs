using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Data.Models;

public class StudentStats
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    
    [Required]
    public Guid StudentId { get; set; } 
    public Student Student { get; set; }

    
    [Required]
    public Guid InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    

    [Required]
    public DateTime PhysicalAssessmentDate { get; set; }
    [Required]
    public float FatBody { get; set; }
    [Required]
    public float LeanMass { get; set; }
    [Required]
    public float CurrentWeight { get; set; }
}