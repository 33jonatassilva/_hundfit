using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IInstructorRepository
{
    Task<Instructor> CreateAsync(Instructor instructor);
    Task<IEnumerable<Instructor>> GetAllAsync();
    Task<Instructor?> GetByIdAsync(Guid id);
    Task<Instructor?> GetByIdWithStudentsAsync(Guid id);
    Task<Instructor> UpdateAsync(Instructor instructor);
    Task DeleteAsync(Guid id);
}