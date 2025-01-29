namespace HundFit.Models;

public class StudentDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }
    public DateTime RegistrationDate  { get; set; }
}