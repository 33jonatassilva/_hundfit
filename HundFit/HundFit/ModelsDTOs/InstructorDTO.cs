using HundFit.Models.Enums;

namespace HundFit.Models;

public class InstructorDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Specialty { get; set; }
    public ESpecialty SpecialtyEnum { get; set; }
    
}