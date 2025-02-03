using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface ITrainingRepository
{
    Task<Training> CreateAsync(Training training); 
    Task<IEnumerable<Training>> GetAllAsync();
    Task<Training> GetByIdWithExercisesAsync(Guid trainingId);
    Task<Training> GetByIdAsync(Guid id);
    Task<IEnumerable<Training>> GetTrainingsForInstructorIdAsync(Guid instructorId);
    Task<Training> UpdateAsync(Training training);
    Task DeleteAsync(Guid id);
    
    
}