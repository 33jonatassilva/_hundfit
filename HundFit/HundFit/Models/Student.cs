using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HundFit.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; }

    [Required, MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required, MaxLength(250)]
    public string Email { get; set; }

    [Required, MaxLength(50)]
    public string PhoneNumber { get; set; }

    [Required, MaxLength(250)]
    public string Address { get; set; }

    [Required]
    public float Weight { get; set; }

    [Required]
    public float Height { get; set; }

    [Required]
    public DateTime RegistrationDate { get; set; }

    // Relacionamento um-para-muitos com Plan
    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }

    // Relacionamento um-para-um opcional com Training
    public Guid? TrainingId { get; set; }
    public Training Training { get; set; }
}