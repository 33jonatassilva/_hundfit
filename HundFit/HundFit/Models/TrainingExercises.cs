using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HundFit.Models;

public class TrainingExercises
{
    [Key]
    public Guid Id { get; set; }

    // Configurando corretamente a relação com Training
    [Required]
    public Guid TrainingId { get; set; }
    [ForeignKey("TrainingId")]
    public Training Training { get; set; }

    // Configurando corretamente a relação com Exercise
    [Required]
    public Guid ExerciseId { get; set; }
    [ForeignKey("ExerciseId")]
    public Exercise Exercise { get; set; }
}