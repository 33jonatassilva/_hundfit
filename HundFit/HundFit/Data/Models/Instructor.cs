using System.ComponentModel.DataAnnotations;
using HundFit.Data.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Data.Models;

public class Instructor
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(50)]
    public string FirstName { get; set; }

    [Required, MaxLength(50)]
    public string LastName { get; set; }

    [Required, MaxLength(255)]
    public string Email { get; set; }

    [Required, MaxLength(50)]
    public string PhoneNumber { get; set; }

    [Required]
    public ESpecialty SpecialtyEnum { get; set; }
    
    
    public virtual ICollection<Student> Students { get; set; }
}