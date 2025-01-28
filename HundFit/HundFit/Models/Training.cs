namespace HundFit.Models;

public class Training
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DurationInMinutes { get; set; }
    
    public Guid StudentId { get; set; }
    public Guid InstructorId { get; set; }
    
    
    public List<Exercise> Exercises { get; set; }
    
    
    
    public Instructor Instructor { get; set; }
}