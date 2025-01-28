using HundFit.Models;

namespace HundFit.Repositories.Interfaces;

public interface IPhysicalAssessmentRepository
{
    /*public PhysicalAssessment Create(PhysicalAssessment physicalAssessment);
    public List<PhysicalAssessment> GetAll();
    public PhysicalAssessment GetById(Guid id);
    public PhysicalAssessment Update(PhysicalAssessment physicalAssessment);
    public PhysicalAssessment Delete(PhysicalAssessment physicalAssessment);*/
    
    
    Task<PhysicalAssessment> CreateAsync(PhysicalAssessment physicalAssessment);
    Task<IEnumerable<PhysicalAssessment>> GetAllAsync();
    Task<PhysicalAssessment> GetByIdAsync(Guid id);
    Task<PhysicalAssessment> UpdateAsync(PhysicalAssessment physicalAssessment);
    Task<PhysicalAssessment> DeleteAsync(Guid id);
    
}