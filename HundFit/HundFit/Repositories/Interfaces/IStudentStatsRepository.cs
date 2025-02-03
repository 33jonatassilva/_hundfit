using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IStudentStatsRepository
{
    Task<StudentStats> CreateAsync(StudentStats studentStats);
    Task<IEnumerable<StudentStats>> GetAllAsync();
    Task<StudentStats> GetByIdAsync(Guid id);
    Task<StudentStats> UpdateAsync(StudentStats studentStats);
    Task DeleteAsync(Guid id);
    
}