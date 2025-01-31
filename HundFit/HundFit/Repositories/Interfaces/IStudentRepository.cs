using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IStudentRepository
{
    /*public Student Create(Student student);
    public List<Student> GetAll();
    public Student GetById(Guid id);
    public Student Update(Student student);
    public Student Delete(Student student);*/
    
    
    Task<Student> CreateAsync(Student student);
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(Guid id);
    Task<Student> UpdateAsync(Student student);
    Task<Student> DeleteAsync(Guid id);
    
    
}