using System.ComponentModel.DataAnnotations;
using HundFit.Models.Enums;

namespace HundFit.Models;

public class Instructor
{
    [Key]
    public Guid Id { get; set; }

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

    // Relacionamento com Training (um-para-muitos)
    public List<Training> Trainings { get; set; } = new();
}