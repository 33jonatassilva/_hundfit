using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student student);
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(Guid id);
    Task<Student> GetByIdWithStudentStatsAsync(Guid id);
    
    Task<Student> UpdateAsync(Student student);
    Task DeleteAsync(Guid id);
    
    
}