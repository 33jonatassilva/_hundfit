using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IPlanRepository
{
    /*public Plan Create(Plan plan);
    public List<Plan> GetAll();
    public Plan GetById(Guid id);
    public Plan Update(Plan plan);
    public Plan Delete(Plan plan);*/
    
    
    public Task<Plan> CreateAsync(Plan physicalAssessment);
    public Task<IEnumerable<Plan>> GetAllAsync();
    public Task<Plan> GetByIdAsync(Guid id);
    public Task<Plan> UpdateAsync(Plan physicalAssessment);
    public Task<Plan> DeleteAsync(Guid id);
}