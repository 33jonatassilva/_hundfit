using System.ComponentModel.DataAnnotations;

namespace HundFit.Models;

public class PhysicalAssessment
{
    [Key]
    public Guid Id { get; set; }

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
    public float ActualWeight { get; set; }
}