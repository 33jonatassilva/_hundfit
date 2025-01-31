using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IInstructorRepository
{
    /*public Instructor Create(Instructor instructor);
    public List<Instructor> GetAll();
    public Instructor GetById(Guid id);
    public Instructor Update(Instructor instructor);
    public Instructor Delete(Instructor instructor);*/
    
    
    Task<Instructor> CreateAsync(Instructor instructor);
    Task<IEnumerable<Instructor>> GetAllAsync();
    Task<Instructor> GetByIdAsync(Guid id);
    Task<Instructor> UpdateAsync(Instructor instructor);
    Task<Instructor> DeleteAsync(Guid id);
}