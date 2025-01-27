namespace HundFit.Models;

public class Exercise
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Repetitions { get; set; }
    public float Load { get; set; }
    public Guid TrainingId { get; set; }
}