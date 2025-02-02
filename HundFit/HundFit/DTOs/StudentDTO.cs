namespace HundFit.DTOs;

public class StudentDTO
{
    public Guid? PlanId { get; set; }
    public Guid? InstructorId { get; set; }
    public Guid? TrainingId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime RegistrationDate { get; set; }
}
