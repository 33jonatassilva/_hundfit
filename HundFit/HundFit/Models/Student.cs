namespace HundFit.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }
    public DateTime StartDate { get; set; }
    public Guid PlanId { get; set; }
    
    public Guid TrainingId { get; set; }

    
    public Plan Plan { get; set; }
}