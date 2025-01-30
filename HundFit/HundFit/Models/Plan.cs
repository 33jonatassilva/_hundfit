
using System.ComponentModel.DataAnnotations;

namespace HundFit.Models;

public class Plan
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public float Price { get; set; }

    [Required]
    public int DurationInMonths { get; set; }

    // Relacionamento com Student (um-para-muitos)
    public List<Student> Students { get; set; } = new();
}