using HundFit.Models;

namespace HundFit.Repositories.Interfaces;

public interface IExerciseRepository
{
    
    public Exercise CreateExercise(Exercise exercise);
    public List<Exercise> GetExercises();
    public Exercise GetExerciseById(Guid id);
    public Exercise Update(Exercise exercise);
    public Exercise DeleteExercise(Exercise exercise);

}