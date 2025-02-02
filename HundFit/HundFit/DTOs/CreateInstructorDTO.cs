using HundFit.Data.Models.Enums;

namespace HundFit.DTOs;

public class CreateInstructorDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ESpecialty SpecialtyEnum { get; set; }
    
}