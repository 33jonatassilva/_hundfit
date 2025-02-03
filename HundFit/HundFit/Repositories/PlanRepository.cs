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


    public async Task<Plan> GetByIdWithStudentsAsync(Guid id)
    {
        return await _context.Plans
            .Include(p => p.Students)
            .FirstOrDefaultAsync(x => x.Id == id);
    }



    public async Task<Plan> UpdateAsync(Plan plan)
    {
        _context.Plans.Update(plan);
        await _context.SaveChangesAsync();
        return plan;
    }


    public async Task DeleteAsync(Guid id)
    {
        
        try
        {
            var plan = await _context.Plans.FirstOrDefaultAsync(x => x.Id == id);
            if (plan == null)
            {
                throw new KeyNotFoundException("Plan not found");
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting plan: {e.Message}", e);
        }
        
        
        /*
      var plan = await _context.Plans.FirstOrDefaultAsync(x => x.Id == id);
      _context.Plans.Remove(plan);
      await _context.SaveChangesAsync();
      return plan;
      */
    }
}