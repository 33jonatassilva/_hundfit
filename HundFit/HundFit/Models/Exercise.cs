using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HundFit.Models;

public class Exercise
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(2500)]
    public string Description { get; set; }

    public int Series { get; set; }
    public int RepetitionsPerSeries { get; set; }
    public float Load { get; set; }

    // Relacionamento correto com TrainingExercises
    public List<TrainingExercises> TrainingExercises { get; set; } = new();
}
