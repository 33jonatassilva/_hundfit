using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface ITrainingRepository
{
    /*public Training Create(Training training);
    public List<Training> GetAll();
    public Training GetById(Guid id);
    public Training Update(Training training);
    public Training Delete(Training training);*/
    
    
    Task<Training> CreateAsync(Training training); 
    Task<IEnumerable<Training>> GetAllAsync();
    Task<Training> GetByIdAsync(Guid id);
    Task<Training> UpdateAsync(Training training);
    Task<Training> DeleteAsync(Guid id);
    Task<IEnumerable<Training>> GetTrainingsForInstructorIdAsync(Guid instructorId);
    
}