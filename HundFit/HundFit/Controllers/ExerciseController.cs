using HundFit.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HundFit.Controllers;


[ApiController]
[Route("/exercise")]

public class ExerciseController : ControllerBase
{
    private readonly IExerciseRepository _repository;

    public ExerciseController(IExerciseRepository repository)
    {
        _repository = repository;
    }
    

    [HttpGet]
    [Route("/")]
    public IActionResult GetExercises()
    {
        var result = _repository.GetExercises();
        return Ok(result);
    }

    [Route("/{id:int}")]
    public IActionResult GetExercisesById(Guid id)
    {
        var exercise = _repository.GetExerciseById(id);
        return Ok(exercise);
    }
    
    
    
    
}