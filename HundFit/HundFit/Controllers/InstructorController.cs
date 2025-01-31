using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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



    [HttpGet("/instructors/")]

    public async Task<IActionResult> GetInstructorAsync([FromQuery] Guid? id)
    {
        return id.HasValue ? Ok(await _repository.GetByIdAsync(id.Value)) : Ok(await _repository.GetAllAsync());
    }
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetInstructorsAsync()
    {
        var result = await _repository.GetAllAsync();
        return Ok(result);
    }
    
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetInstructorsByIdAsync(Guid id)
    {
        var instructor = await _repository.GetByIdAsync(id);
        return Ok(instructor);
    }
    


    [HttpPut("/Instructors/{id:guid}")]
    public async Task<IActionResult> UpdateInstructorAsync(Guid id, [FromBody] Instructor instructor)
    {
        var instructorToUpdate = await _repository.GetByIdAsync(id);

        instructorToUpdate.Id = instructor.Id;
        instructorToUpdate.FirstName = instructor.FirstName;
        instructorToUpdate.LastName = instructor.LastName;
        instructorToUpdate.Email = instructor.Email;
        instructorToUpdate.PhoneNumber = instructor.PhoneNumber;
        instructorToUpdate.SpecialtyEnum = instructor.SpecialtyEnum;

        await _repository.UpdateAsync(instructorToUpdate);
        return Ok(instructorToUpdate);
    }



    [HttpDelete("/instructors/{id:guid}")]
    public IActionResult DeleteInstructorByIdAsync(Guid id)
    {
        var instructor = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(instructor);
    }

}