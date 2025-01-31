using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IStudentStatsRepository
{
    /*public PhysicalAssessment Create(PhysicalAssessment physicalAssessment);
    public List<PhysicalAssessment> GetAll();
    public PhysicalAssessment GetById(Guid id);
    public PhysicalAssessment Update(PhysicalAssessment physicalAssessment);
    public PhysicalAssessment Delete(PhysicalAssessment physicalAssessment);*/
    
    
    Task<StudentStats> CreateAsync(StudentStats studentStats);
    Task<IEnumerable<StudentStats>> GetAllAsync();
    Task<StudentStats> GetByIdAsync(Guid id);
    Task<StudentStats> UpdateAsync(StudentStats studentStats);
    Task<StudentStats> DeleteAsync(Guid id);
    
}