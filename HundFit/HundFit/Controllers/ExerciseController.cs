using HundFit.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HundFit.Controllers;


[ApiController]
[Route("/hundfit/v1/")]

public class ExerciseController : ControllerBase
{
    
    
    
    private readonly IExerciseRepository _repository;

    public ExerciseController(IExerciseRepository repository)
    {
        _repository = repository;
    }
    


    [HttpPost("/exercises")]
    public async Task<IActionResult> CreateExerciseAsync([FromBody] Exercise exercise)
    {
        await _repository.CreateAsync(exercise);
        return Ok(exercise);
    }
    
    
    
    [HttpGet("/exercises")]
    public async Task<IActionResult> GetExercisesAsync()
    {
        var result = await _repository.GetAllAsync();
        return Ok(result);
    }
    
    
    
    [HttpGet("/exercises/{id:guid}")]
    public async Task<IActionResult> GetExercisesByIdAsync(Guid id)
    {
        var exercise = await _repository.GetByIdAsync(id);
        return Ok(exercise);
    }
    


    /*[HttpPut("/exercises/{id:guid}")]
    public IActionResult UpdateExercise(Guid id, [FromBody] Exercise exercise)
    {
        var exerciseToUpdate = _repository.GetExerciseById(id);
        
        exerciseToUpdate.Name = exercise.Name;
        exerciseToUpdate.Description = exercise.Description;
        exerciseToUpdate.TrainingId = exercise.TrainingId;
        exerciseToUpdate.Load = exercise.Load;
        exerciseToUpdate.Repetitions = exercise.Repetitions;
        
        _repository.Update(exerciseToUpdate);
        return Ok(exerciseToUpdate);
    }*/



    [HttpDelete("/exercises/{id:guid}")]
    public async Task<IActionResult> DeleteExerciseByIdAsync(Guid id)
    {
        var exercise = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(id);
        return Ok(exercise);
    }
    
    
    
    
    
    
}