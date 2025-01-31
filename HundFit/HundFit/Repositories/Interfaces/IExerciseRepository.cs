using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IExerciseRepository
{
    
    /*public Exercise CreateExercise(Exercise exercise);
    public List<Exercise> GetExercises();
    public Exercise GetExerciseById(Guid id);
    public Exercise Update(Exercise exercise);
    public Exercise DeleteExercise(Exercise exercise);*/
    
    
    Task<Exercise> CreateAsync(Exercise exercise);
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise> GetByIdAsync(Guid id);
    Task<Exercise> UpdateAsync(Exercise exercise);
    Task<Exercise> DeleteAsync(Guid id);
    

}