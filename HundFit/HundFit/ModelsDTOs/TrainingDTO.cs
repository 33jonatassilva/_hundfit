namespace HundFit.ModelsDTOs;

public class TrainingDTO
{
    public Guid? InstructorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DurationInMinutes { get; set; }
}