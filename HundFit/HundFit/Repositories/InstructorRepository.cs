using HundFit.Data;
using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class InstructorRepository : IInstructorRepository
{
    
    
    
    private readonly AppDbContext _context;

    public InstructorRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    
    public async Task<Instructor> CreateAsync(Instructor instructor)
    {
        await _context.Instructors.AddAsync(instructor);
        await _context.SaveChangesAsync();
        return instructor;
    }


    public async Task<IEnumerable<Instructor>> GetAllAsync()
    {
        return await _context.Instructors.ToListAsync();
    }


    public async Task<Instructor> GetByIdAsync (Guid id)
    {
        return await _context.Instructors.FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<Instructor> UpdateAsync(Instructor instructor)
    {
        var updatedInstructor = _context.Update(instructor).Entity;
        await _context.SaveChangesAsync();
        return updatedInstructor;
    }


    public async Task<Instructor> DeleteAsync(Guid id)
    {
        var instructor = await _context.Instructors.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(id);
        await _context.SaveChangesAsync();
        return instructor;
    }
}