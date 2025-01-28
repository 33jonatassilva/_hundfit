using HundFit.Data;
using HundFit.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class PhysicalAssessmentRepository : IPhysicalAssessmentRepository
{
    
    private readonly AppDbContext _context;

    public PhysicalAssessmentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<PhysicalAssessment> CreateAsync(PhysicalAssessment physicalAssessment)
    {
        await _context.PhysicalAssessments.AddAsync(physicalAssessment);
        await _context.SaveChangesAsync();
        return physicalAssessment;
    }


    public async Task<IEnumerable<PhysicalAssessment>> GetAllAsync()
    {
        return await _context.PhysicalAssessments.ToListAsync();
        
    }


    public async Task<PhysicalAssessment> GetByIdAsync(Guid id)
    {
        return await _context.PhysicalAssessments.FirstOrDefaultAsync(p => p.Id == id);
        
    }


    public async Task<PhysicalAssessment> UpdateAsync(PhysicalAssessment physicalAssessment)
    {
        _context.PhysicalAssessments.Update(physicalAssessment);
        await _context.SaveChangesAsync();
        return physicalAssessment;
    }


    public async Task<PhysicalAssessment> DeleteAsync(Guid id)
    {
        var physicalAssessment = await _context.PhysicalAssessments.FirstOrDefaultAsync(x => x.Id == id);
        _context.PhysicalAssessments.Remove(physicalAssessment);
        await _context.SaveChangesAsync();
        return physicalAssessment;
    }
    
    
}