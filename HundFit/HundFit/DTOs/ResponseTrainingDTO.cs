namespace HundFit.DTOs;

public class ResponseTrainingDTO
{
   
    public Guid Id { get; set; }
    public Guid? InstructorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DurationInMinutes { get; set; }
    
    public List<ExerciseDTO> Exercises { get; set; }
}