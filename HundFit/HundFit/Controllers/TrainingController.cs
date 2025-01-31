using HundFit.Data.Models;
using HundFit.ModelsDTOs;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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


    /*[HttpPut("/exercise/{trainingId:guid}")]
    public async Task<IActionResult> AddExerciseToTrainingAsync([FromRoute] Guid trainingId, [FromBody] ExerciseDTO exerciseDto)
    {
        
        var training = await _repository.GetByIdAsync(trainingId);
        var exercise = new Exercise
        {
            Name = exerciseDto.Name,
            Description = exerciseDto.Description,
            Series = exerciseDto.Series,
            RepetitionsPerSeries = exerciseDto.RepetitionsPerSeries,
            Load = exerciseDto.Load,
            Training = new List<Training>()
        };
        
        
       
       training.Exercises.Add(exercise);
       await _repository.UpdateAsync(training);
       return Ok(exercise);
    }*/
    
    
    
    
    [HttpPut("/exercise/{trainingId:guid}")]
    public async Task<IActionResult> AddExerciseToTrainingAsync([FromRoute] Guid trainingId, [FromBody] ExerciseDTO exerciseDto)
    {
        // Buscar o treinamento no repositório
        var training = await _repository.GetByIdAsync(trainingId);

        // Se não encontrar, retorna 404
        if (training == null)
        {
            return NotFound("Treinamento não encontrado.");
        }

        // Inicializar a coleção se for nula
        if (training.Exercises == null)
        {
            training.Exercises = new List<Exercise>();
        }

        // Criar um novo exercício
        var exercise = new Exercise
        {
            Name = exerciseDto.Name,
            Description = exerciseDto.Description,
            Series = exerciseDto.Series,
            RepetitionsPerSeries = exerciseDto.RepetitionsPerSeries,
            Load = exerciseDto.Load,
            Training = new List<Training> { training }  // Correção
        };

        // Adicionar o exercício ao treinamento
        training.Exercises.Add(exercise);

        // Atualizar o treinamento no banco de dados
        await _repository.UpdateAsync(training);

        // Retornar resposta de sucesso
        return Ok(exercise);
    }




    [HttpDelete("/training/{id:guid}")]
    public async Task<IActionResult> DeleteTrainingByIdAsync(Guid id)
    {
        var training = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(training);
    }
}