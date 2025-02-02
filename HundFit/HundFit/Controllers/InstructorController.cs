using HundFit.Data.Models;
using HundFit.DTOs;
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
    public async Task<IActionResult> CreateInstructorAsync([FromBody] CreateInstructorDTO instructorDto)
    {

        var instructor = new Instructor
        {
            FirstName = instructorDto.FirstName,
            LastName = instructorDto.LastName,
            Email = instructorDto.Email,
            PhoneNumber = instructorDto.PhoneNumber,
            SpecialtyEnum = instructorDto.SpecialtyEnum
        };
        
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
    public async Task<IActionResult> UpdateInstructorAsync(Guid id, [FromBody] UpdateInstructorDTO instructorDto)
    {
        var instructor = await _repository.GetByIdAsync(id);
        
        instructor.FirstName = instructorDto.FirstName;
        instructor.LastName = instructorDto.LastName;
        instructor.Email = instructorDto.Email;
        instructor.PhoneNumber = instructorDto.PhoneNumber;
        instructor.SpecialtyEnum = instructorDto.SpecialtyEnum;

        await _repository.UpdateAsync(instructor);
        return Ok(instructor);
    }



    [HttpDelete("/instructors/{id:guid}")]
    public IActionResult DeleteInstructorByIdAsync(Guid id)
    {
        var instructor = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(instructor);
    }

}