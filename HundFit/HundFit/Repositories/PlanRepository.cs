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
        try
        {
            await _context.Plans.AddAsync(plan);
            await _context.SaveChangesAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        try
        {
            return await _context.Plans.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Plan> GetByIdAsync(Guid id)
    {
        try
        {
            var plan = await _context.Plans.FirstOrDefaultAsync(x => x.Id == id);

            if (plan == null) throw new KeyNotFoundException("Plan not found");
            
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Plan> GetByIdWithStudentsAsync(Guid id)
    {
        try
        {
            var plans = await _context.Plans
                .Include(p => p.Students)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (plans == null) throw new KeyNotFoundException("Plans not found");
            
            return plans;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }



    public async Task<Plan> UpdateAsync(Plan plan)
    {
        try
        {
            _context.Plans.Update(plan);
            await _context.SaveChangesAsync();
            return plan;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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