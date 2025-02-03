using HundFit.Data.Models;

namespace HundFit.Repositories.Interfaces;

public interface IPlanRepository
{
    public Task<Plan> CreateAsync(Plan physicalAssessment);
    public Task<IEnumerable<Plan>> GetAllAsync();
    public Task<Plan> GetByIdWithStudentsAsync(Guid id);
    public Task<Plan> GetByIdAsync(Guid id);
    public Task<Plan> UpdateAsync(Plan physicalAssessment);
    public Task DeleteAsync(Guid id);
}