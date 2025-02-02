namespace HundFit.DTOs;

public class ExerciseDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Series { get; set; }
    public int RepetitionsPerSeries { get; set; }
    public float Load { get; set; }
    
}