using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Data.Models;

public class Training
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    
    
    /*public Guid? StudentId { get; set; } 
    public Student Student { get; set; }*/
    public Guid? InstructorId { get; set; }
    public Instructor Instructor { get; set; }

    

    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required, MaxLength(2500)]
    public string Description { get; set; }
    [Required]
    public int DurationInMinutes { get; set; }
    
    
    public virtual ICollection<Exercise> Exercises { get; set; }
}
