using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Data.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? PlanId { get; set; }
    public Plan Plan { get; set; }
    public Guid? InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public Guid? TrainingId { get; set; }
    public Training Training { get; set; }
    
    
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    
    
    public virtual ICollection<StudentStats> StudentStats { get; set; }

    
}