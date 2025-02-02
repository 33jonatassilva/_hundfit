namespace HundFit.DTOs;

public class CreateStudentStatsDTO
{
    public Guid StudentId { get; set; }
    public Guid InstructorId { get; set; }
    public float FatBody { get; set; }
    public float LeanMass { get; set; }
    public float CurrentWeight { get; set; }
}