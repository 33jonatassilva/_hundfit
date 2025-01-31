using HundFit.Data;
using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly AppDbContext _context;


    public PlanRepository(AppDbContext context)
    {
        _context = context;
    }



    public async Task<Plan> CreateAsync(Plan plan)
    {
        await _context.Plans.AddAsync(plan);
        await _context.SaveChangesAsync();
        return plan;
    }


    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        return await _context.Plans.ToListAsync();
    }


    public async Task<Plan> GetByIdAsync(Guid id)
    {
        return await _context.Plans.FirstOrDefaultAsync(x => x.Id == id);
    }



    public async Task<Plan> UpdateAsync(Plan plan)
    {
        _context.Plans.Update(plan);
        await _context.SaveChangesAsync();
        return plan;
    }


    public async Task<Plan> DeleteAsync(Guid id)
    {
        var plan = await _context.Plans.FirstOrDefaultAsync(x => x.Id == id);
        _context.Plans.Remove(plan);
        await _context.SaveChangesAsync();
        return plan;
    }
}