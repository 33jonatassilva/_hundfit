using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HundFit.Models;

public class PhysicalAssessment
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Guid StudentId { get; set; }
    
    [Required]
    public Guid InstructorId { get; set; }
    
    [Required]
    public DateTime PhysicalAssessmentDate { get; set; }
    
    [Required]
    public float FatBody { get; set; }
    
    [Required]
    public float LeanMass { get; set; }
    
    [Required]
    public float ActualWeight { get; set; }
    
    [JsonIgnore]
    public Student Student { get; set; }
    [JsonIgnore]
    public Instructor Instructor { get; set; }

}