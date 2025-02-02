using System.ComponentModel.DataAnnotations;
using Azure.Core;
using HundFit.Data.Models;
using HundFit.DTOs;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Controllers;


[ApiController]
[Route("/training")]

public class TrainingController :ControllerBase
{
    
    private readonly ITrainingRepository _repository;
    private readonly IExerciseRepository _exerciseRepository;

    public TrainingController(ITrainingRepository repository, IExerciseRepository exerciseRepository)
    {
        _repository = repository;
        _exerciseRepository = exerciseRepository;
    }
    
    
    
    
    
    [HttpPost("/training/")]
    public async Task<IActionResult> CreateTrainingAsync([FromBody] TrainingDTO trainingDto)
    {


        var training = new Training
        {
            InstructorId = trainingDto.InstructorId,
            Name = trainingDto.Name,
            Description = trainingDto.Description,
            DurationInMinutes = trainingDto.DurationInMinutes

        };
        
        
        await _repository.CreateAsync(training);
        return Ok(training);
    }
    
    

    [HttpGet("/training/")]
    public async Task<IActionResult> GetTrainingAsync([FromQuery] Guid? id)
    {
        return id.HasValue ? Ok(await _repository.GetByIdAsync(id.Value)) : Ok(await _repository.GetAllAsync());
    }
    
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetTrainingsAsync()
    {
        var trainings = await _repository.GetAllAsync();
        return Ok(trainings);
    }
    
    
    [HttpGet("exercises/")]
    public async Task<IActionResult> GetExercisesByTrainingId([FromQuery, Required] Guid id)
    {
        
        var training = await _repository.GetTrainingsWithExercisesAsync(id);
        
        var exercises = training.Exercises.Select(e => new ExerciseDTO
        {
            Name = e.Name,
            Description = e.Description,
            Series = e.Series,
            RepetitionsPerSeries = e.RepetitionsPerSeries
        }).ToList();

        return Ok(exercises);
    }

    
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetTrainingsByIdAsync(Guid id)
    {
        var training = await _repository.GetByIdAsync(id);
        return Ok(training);
    }
    


    [HttpPut("/trainings/{id:guid}")]
    public async Task<IActionResult> UpdateTrainingAsync(Guid id, [FromBody] TrainingDTO trainingDto)
    {
        var training = await _repository.GetByIdAsync(id);
        
        training.InstructorId = trainingDto.InstructorId;
        training.Name = trainingDto.Name;
        training.Description = trainingDto.Description;
        training.DurationInMinutes = trainingDto.DurationInMinutes;
        
        
        await _repository.UpdateAsync(training);
        return Ok(training);
    }


    [HttpPut("/training/exercise/asign")]
    public async Task<IActionResult> AddExerciseToTrainingAsync([FromQuery, Required] Guid trainingId, [FromQuery, Required] Guid exerciseId)
    {
        var training = await _repository.GetByIdAsync(trainingId);

        var exercise = await _exerciseRepository.GetByIdAsync(exerciseId);
        
        //training.Exercises = new List<Exercise>();
        
        training.Exercises.Add(exercise);
        
        await _repository.UpdateAsync(training);
        return Ok(training);
       
    }
    
    
    
    [HttpPost("/training/exercise/add")]
    public async Task<IActionResult> AddExerciseToTrainingAsync(Guid id, [FromBody] CreateExerciseDTO exerciseDto)
    {
        var training = await _repository.GetByIdAsync(id);
        
        if (training == null)
        {
            return NotFound("Treinamento não encontrado.");
        }

        training.Exercises ??= new List<Exercise>();

        var exercise = new Exercise
        {
            Id = Guid.NewGuid(),
            Name = exerciseDto.Name,
            Description = exerciseDto.Description,
            Series = exerciseDto.Series,
            RepetitionsPerSeries = exerciseDto.RepetitionsPerSeries
        };

        training.Exercises.Add(exercise);
        //await _repository.UpdateAsync(training);
        await _exerciseRepository.CreateAsync(exercise);

        var response = new ResponseTrainingDTO
        {
            Id = training.Id,
            Name = training.Name,
            Description = training.Description,
            DurationInMinutes = training.DurationInMinutes,
            Exercises = training.Exercises.Select(e => new ExerciseDTO
            {
                Name = e.Name,
                Description = e.Description,
                Series = e.Series,
                RepetitionsPerSeries = e.RepetitionsPerSeries
            }).ToList()
        };

        return Ok(response);

    }
    


    [HttpDelete("/training/{id:guid}")]
    public async Task<IActionResult> DeleteTrainingByIdAsync(Guid id)
    {
        var training = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(training);
    }
}