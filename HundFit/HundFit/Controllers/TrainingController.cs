using HundFit.Data.Models;
using HundFit.ModelsDTOs;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Controllers;


[ApiController]
[Route("/training")]

public class TrainingController :ControllerBase
{
    private readonly ITrainingRepository _repository;

    public TrainingController(ITrainingRepository repository)
    {
        _repository = repository;
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



    [HttpDelete("/training/{id:guid}")]
    public async Task<IActionResult> DeleteTrainingByIdAsync(Guid id)
    {
        var training = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(training);
    }
}