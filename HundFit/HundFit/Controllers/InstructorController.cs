using HundFit.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HundFit.Controllers;


[ApiController]
[Route("instructor")]

public class InstructorController : ControllerBase
{
    private readonly IInstructorRepository _repository;

    public InstructorController(IInstructorRepository repository)
    {
        _repository = repository;
    }
    


    [HttpPost("/instructor")]
    public async Task<IActionResult> CreateInstructorAsync([FromBody] Instructor instructor)
    {
        await _repository.CreateAsync(instructor);
        return Ok(instructor);
    }
    
    
    
    [HttpGet("/instructors")]
    public async Task<IActionResult> GetInstructorsAsync()
    {
        var result = await _repository.GetAllAsync();
        return Ok(result);
    }
    
    
    
    [HttpGet("/instructors/{id:guid}")]
    public async Task<IActionResult> GetInstructorsByIdAsync(Guid id)
    {
        var instructor = await _repository.GetByIdAsync(id);
        return Ok(instructor);
    }
    


    /*[HttpPut("/Instructors/{id:guid}")]
    public IActionResult UpdateInstructor(Guid id, [FromBody] Instructor Instructor)
    {
        var InstructorToUpdate = _repository.GetInstructorById(id);

        InstructorToUpdate.Name = Instructor.Name;
        InstructorToUpdate.Description = Instructor.Description;
        InstructorToUpdate.TrainingId = Instructor.TrainingId;
        InstructorToUpdate.Load = Instructor.Load;
        InstructorToUpdate.Repetitions = Instructor.Repetitions;

        _repository.Update(InstructorToUpdate);
        return Ok(InstructorToUpdate);
    }*/



    [HttpDelete("/Instructors/{id:guid}")]
    public IActionResult DeleteInstructorByIdAsync(Guid id)
    {
        var instructor = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(instructor);
    }

}