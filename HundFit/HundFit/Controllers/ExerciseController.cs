using HundFit.Data.Models;
using HundFit.DTOs;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    public async Task<IActionResult> CreateExerciseAsync([FromBody] ExerciseDTO exerciseDto)
    {
        var exercise = new Exercise
        {
            Id = Guid.NewGuid(),
            Name = exerciseDto.Name,
            Description = exerciseDto.Description,
            Series = exerciseDto.Series,
            RepetitionsPerSeries = exerciseDto.RepetitionsPerSeries,
            Load = exerciseDto.Load
        };
        
        await _repository.CreateAsync(exercise);
        return Ok(exerciseDto);
    }
    
    
    


    [HttpGet("/exercises/")]
    public async Task<IActionResult> GetExerciseAsync([FromQuery] Guid? id)
    {
        return id.HasValue ? Ok(await _repository.GetByIdAsync(id.Value)) : Ok(await GetExercisesAsync());
    }
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetExercisesAsync()
    {
        var result = await _repository.GetAllAsync();
        return Ok(result);
    }
    
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetExercisesByIdAsync(Guid id)
    {
        var exercise = await _repository.GetByIdAsync(id);
        return Ok(exercise);
    }
    


    [HttpPut("/exercises/{id:guid}")]
    public async Task<IActionResult> UpdateExercise(Guid id, [FromBody] ExerciseDTO exerciseDto)
    {
        var exercise = await _repository.GetByIdAsync(id);
        
        exercise.Name = exerciseDto.Name;
        exercise.Description = exerciseDto.Description;
        exercise.Series = exerciseDto.Series;
        exercise.Load = exerciseDto.Load;
        
        
        await _repository.UpdateAsync(exercise);
        return Ok(exercise);
    }



    [HttpDelete("/exercises/{id:guid}")]
    public async Task<IActionResult> DeleteExerciseByIdAsync(Guid id)
    {
        var exercise = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(id);
        return Ok(exercise);
    }
    
    
    
    
    
    
}