using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HundFit.Data.Models;

public class TrainingExercises
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid TrainingId { get; set; }
    public Training Training { get; set; }


    [Required]
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
}