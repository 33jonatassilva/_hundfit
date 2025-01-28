
namespace HundFit.Models;

public class Plan
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int DurationInMonths { get; set; }
    
    public List<Student> Students { get; set; }
}