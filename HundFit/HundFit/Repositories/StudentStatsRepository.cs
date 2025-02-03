using HundFit.Data;
using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class StudentStatsRepository : IStudentStatsRepository
{
    
    private readonly AppDbContext _context;

    public StudentStatsRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<StudentStats> CreateAsync(StudentStats studentStats)
    {
        try
        {
            await _context.StudentStats.AddAsync(studentStats);
            await _context.SaveChangesAsync();
            return studentStats;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IEnumerable<StudentStats>> GetAllAsync()
    {
        try
        {
            return await _context.StudentStats.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<StudentStats> GetByIdAsync(Guid id)
    {
        
        try
        {
            var studentStats = await _context.StudentStats.FirstOrDefaultAsync(x => x.Id == id);
            if (studentStats == null)
            {
                throw new KeyNotFoundException("StudentStats not found");
            }

            return studentStats;
        }
        catch (Exception e)
        {
            throw new Exception($"Error Search StudentStats: {e.Message}", e);
        }
        
    }


    public async Task<StudentStats> UpdateAsync(StudentStats studentStats)
    {
        try
        {
            _context.StudentStats.Update(studentStats);
            await _context.SaveChangesAsync();
            return studentStats;
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
            var studentStats = await _context.StudentStats.FirstOrDefaultAsync(x => x.Id == id);
            if (studentStats == null)
            {
                throw new KeyNotFoundException("StudentStats not found");
            }

            _context.StudentStats.Remove(studentStats);
            await _context.SaveChangesAsync(); 
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting StudentStats: {e.Message}", e);
        }
        
        /*var studentStats = await _context.StudentStats.FirstOrDefaultAsync(x => x.Id == id);
        _context.StudentStats.Remove(studentStats);
        await _context.SaveChangesAsync();
        return studentStats;*/


        
    }
    
    
}