namespace HundFit.Models;

public class TrainingExercises
{
    public Guid TrainingId { get; set; }
    public Training Training { get; set; }


    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
}