using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HundFit.Models;

public class Training
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(2500)]
    public string Description { get; set; }
    
    [Required]
    public int DurationInMinutes { get; set; }
    
    public Guid StudentId { get; set; }
    public Guid InstructorId { get; set; }
    
    
    public List<Exercise> Exercises { get; set; }
    
    
    [JsonIgnore]
    public Instructor Instructor { get; set; }
}