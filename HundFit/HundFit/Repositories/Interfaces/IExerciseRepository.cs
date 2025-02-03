using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IExerciseRepository
{
    Task<Exercise> CreateAsync(Exercise exercise);
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise> GetByIdAsync(Guid id);
    Task<Exercise> UpdateAsync(Exercise exercise);
    Task DeleteAsync(Guid id);
    

}