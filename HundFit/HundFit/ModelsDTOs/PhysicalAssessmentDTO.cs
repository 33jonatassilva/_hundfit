namespace HundFit.Models;

public class PhysicalAssessmentDTO
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime PhysicalAssessmentDate { get; set; }
    public float FatBody { get; set; }
    public float LeanMass { get; set; }
    public float ActualWeight { get; set; }
}