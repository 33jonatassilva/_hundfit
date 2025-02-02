namespace HundFit.DTOs;

public class StudentStatsDTO
{
    public Guid StudentId { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime PhysicalAssessmentDate { get; set; }
    public float FatBody { get; set; }
    public float LeanMass { get; set; }
    public float CurrentWeight { get; set; }
}