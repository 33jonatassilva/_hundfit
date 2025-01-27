namespace HundFit.Models;

public class PhysicalAssessment
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime AssessmentDate { get; set; }
    public float FatBody { get; set; }
    public float LeanMass { get; set; }
    public float ActualWeight { get; set; }
}