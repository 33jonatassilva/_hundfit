using HundFit.Models;
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
    public async Task<IActionResult> CreateTrainingAsync([FromBody] Training training)
    {
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
    


    /*[HttpPut("/trainings/{id:guid}")]
    public IActionResult Updatetraining(Guid id, [FromBody] training training)
    {
        var trainingToUpdate = _repository.GettrainingById(id);

        trainingToUpdate.Name = training.Name;
        trainingToUpdate.Description = training.Description;
        trainingToUpdate.TrainingId = training.TrainingId;
        trainingToUpdate.Load = training.Load;
        trainingToUpdate.Repetitions = training.Repetitions;

        _repository.Update(trainingToUpdate);
        return Ok(trainingToUpdate);
    }*/



    [HttpDelete("/training/{id:guid}")]
    public async Task<IActionResult> DeleteTrainingByIdAsync(Guid id)
    {
        var training = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(training);
    }
}