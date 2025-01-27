using HundFit.Data;
using HundFit.Models;
using HundFit.Repositories.Interfaces;

namespace HundFit.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    
    private readonly AppDbContext _context;

    public ExerciseRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    public Exercise CreateExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        _context.SaveChanges();
        return exercise;
    }


    public List<Exercise> GetExercises()
    {
        return _context.Exercises.ToList();
    }


    public Exercise GetExerciseById(Guid id)
    {
        return _context.Exercises.FirstOrDefault(x => x.Id == id);
    }


    public Exercise Update(Exercise exercise)
    {
        var updatedExercise = _context.Update(exercise).Entity;
        _context.SaveChanges();
        return updatedExercise;
    }


    public Exercise DeleteExercise(Exercise exercise)
    {
        _context.Remove(exercise);
        _context.SaveChanges();
        return exercise;
    }
    
}