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
    public IActionResult CreateExercise([FromBody] Exercise exercise)
    {
        _repository.CreateExercise(exercise);
        return Ok(exercise);
    }
    
    
    
    [HttpGet("/exercises")]
    public IActionResult GetExercises()
    {
        var result = _repository.GetExercises();
        return Ok(result);
    }
    
    
    
    [HttpGet("/exercises/{id:guid}")]
    public IActionResult GetExercisesById(Guid id)
    {
        var exercise = _repository.GetExerciseById(id);
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
    public IActionResult DeleteExerciseById(Guid id)
    {
        var exercise = _repository.GetExerciseById(id);
        _repository.DeleteExercise(exercise);
        return Ok(exercise);
    }
    
    
    
    
    
    
}