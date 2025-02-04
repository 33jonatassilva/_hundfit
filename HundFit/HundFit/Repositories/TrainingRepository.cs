using HundFit.Data;
using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HundFit.Repositories;

public class TrainingRepository : ITrainingRepository
{
    
    private readonly AppDbContext _context;


    public TrainingRepository(AppDbContext context)
    {
        _context = context;
    }



    public async Task<Training> CreateAsync(Training training)
    {
        try
        {
            await _context.Trainings.AddAsync(training);
            await _context.SaveChangesAsync();
            return training;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task<IEnumerable<Training>> GetAllAsync()
    {
        try
        {
            return await _context.Trainings.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    
    public async Task<Training> GetByIdAsync(Guid id)
    {
        
        try
        {
            var training = await _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
            
            if (training == null)
            {
                throw new KeyNotFoundException("Training not found");
            }

            return training;
        }
        catch (Exception e)
        {
            throw new Exception($"Error Search Training: {e.Message}", e);
        }
    }

    public async Task<Training> GetByIdWithExercisesAsync(Guid id)
    {
        try
        {
            var trainings = await _context.Trainings
                .Include(t => t.Exercises)
                .FirstOrDefaultAsync(t => t.Id == id);
            
            if (trainings == null)
                throw new KeyNotFoundException("Trainings not found");
            
            return trainings;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    public async Task<IEnumerable<Training>> GetTrainingsForInstructorIdAsync(Guid instructorId)
    {
        return await _context.Trainings.Where(x => x.InstructorId == instructorId).ToListAsync();
    }


    public async Task<Training> UpdateAsync(Training training)
    {
        try
        {
            _context.Trainings.Update(training);
            
            if(_context.ChangeTracker.HasChanges())
                Console.WriteLine("Has changes!!!");
            else
            {
                Console.WriteLine("No changes!!!");
            }
            await _context.SaveChangesAsync();
            return training;
        }
        catch (Exception e)
        {
            throw new Exception($"Error Updating Training: {e.Message}", e);
        }
    }


    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var training = await _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
            
            if (training == null)
            {
                throw new KeyNotFoundException("Training not found");
            }

            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync(); 
        }
        catch (Exception e)
        {
            throw new Exception($"Error deleting Training: {e.Message}", e);
        }
        
        
        /*var training = await _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
        _context.Trainings.Remove(training);
        await _context.SaveChangesAsync();
        return training;*/


    }

   
}