
namespace HundFit.Models;

public class PlanDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int DurationInMonths { get; set; }
}