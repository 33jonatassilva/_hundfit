using HundFit.Data;
using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    
    private readonly AppDbContext _context;

    public ExerciseRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<Exercise> CreateAsync(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }


    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await _context.Exercises.ToListAsync();
    }


    public async Task<Exercise> GetByIdAsync(Guid id)
    {
        return await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<Exercise> UpdateAsync(Exercise exercise)
    {
        var updatedExercise = _context.Update(exercise).Entity;
        await _context.SaveChangesAsync();
        return updatedExercise;
    }


    public async Task<Exercise> DeleteAsync(Guid id)
    {
        var exercise = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }
    
    
    
}