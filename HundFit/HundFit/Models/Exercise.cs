namespace HundFit.Models;

public class Exercise
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Series { get; set; }
    public int RepetitionsPerSeries { get; set; }
    public float Load { get; set; }
    
    public Guid TrainingId { get; set; }
    public Training Training { get; set; }
    
    public List<TrainingExercises> TrainingExercises { get; set; }
    
}