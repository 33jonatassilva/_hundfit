using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HundFit.Models;

public class ExerciseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Series { get; set; }
    public int RepetitionsPerSeries { get; set; }
    public float Load { get; set; }
    
}