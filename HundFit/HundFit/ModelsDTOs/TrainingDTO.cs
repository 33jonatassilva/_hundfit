namespace HundFit.Models;

public class TrainingDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DurationInMinutes { get; set; }
}