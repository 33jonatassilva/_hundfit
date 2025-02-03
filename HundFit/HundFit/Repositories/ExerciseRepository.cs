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
        try
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        try
        {
            return await _context.Exercises.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Exercise> GetByIdAsync(Guid id)
    {
        try
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);

            if (exercise == null)
            {
                throw new KeyNotFoundException("Exercise not found");
            }
            
            return exercise;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<Exercise> UpdateAsync(Exercise exercise)
    {
        try
        {
            var updatedExercise = _context.Update(exercise).Entity;
            await _context.SaveChangesAsync();
            return updatedExercise;
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
            var exercise = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
            if (exercise == null)
            {
                throw new KeyNotFoundException("Exercise not found");
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync(); 
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting exercise: {e.Message}", e);
        }
        
        /*var exercise = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(exercise);
        await _context.SaveChangesAsync();
        return exercise;*/

    }



}