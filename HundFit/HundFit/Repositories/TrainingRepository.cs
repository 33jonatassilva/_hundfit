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
        await _context.Trainings.AddAsync(training);
        await _context.SaveChangesAsync();
        return training;
    }


    public async Task<IEnumerable<Training>> GetAllAsync()
    {
        return await _context.Trainings.ToListAsync();
    }


    public async Task<Training> GetByIdAsync(Guid id)
    {
        return await _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<Training> UpdateAsync(Training training)
    {
        _context.Trainings.Update(training);
        await _context.SaveChangesAsync();
        return training;
    }


    public async Task<Training> DeleteAsync(Guid id)
    {
        var training = await _context.Trainings.FirstOrDefaultAsync(x => x.Id == id);
        _context.Trainings.Remove(training);
        await _context.SaveChangesAsync();
        return training;
    }

    public async Task<IEnumerable<Training>> GetTrainingsForInstructorIdAsync(Guid instructorId)
    {
        return await _context.Trainings.Where(x => x.InstructorId == instructorId).ToListAsync();
    }
}