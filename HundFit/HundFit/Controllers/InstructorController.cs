using System.ComponentModel.DataAnnotations;
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
    private readonly IStudentRepository _studentRepository;

    public InstructorController(IInstructorRepository repository, IStudentRepository studentRepository)
    {
        _repository = repository;
        _studentRepository = studentRepository;
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

    [HttpPost("/instructor/add-student")]

    public async Task<IActionResult> AddStudentToInstructorAsync(Guid instructorId, StudentDTO studentDto)
    {
        var instructor = await _repository.GetByIdWithStudentsAsync(instructorId);
        
        var student = new Student
        {
            PlanId = studentDto.PlanId,
            InstructorId = instructor.Id,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Email = studentDto.Email,
            PhoneNumber = studentDto.PhoneNumber,
            Address = studentDto.Address,
            RegistrationDate = DateTime.Today
        };

        instructor.Students.Add(student);
        await _repository.UpdateAsync(instructor);
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


    [HttpGet("/instructor/students")]
    public async Task<IActionResult> GetStudentsByInstructorIdAsync([FromQuery, Required] Guid id)
    {
        var instructor = await _repository.GetByIdWithStudentsAsync(id);
        
        var students = instructor.Students.Select(s => new StudentDTO()
        {
            PlanId = s.PlanId,
            InstructorId = s.InstructorId,
            TrainingId = s.TrainingId,
            FirstName = s.FirstName,
            LastName = s.LastName,
            BirthDate = s.BirthDate,
            Email = s.Email,
            PhoneNumber = s.PhoneNumber,
            Address = s.Address,
            RegistrationDate = s.RegistrationDate
            
        }).ToList();
        
        return Ok(students);
    }
    


    [HttpPut("/instructor/{id:guid}")]
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

    [HttpPut("/instructor/student/assign")]

    public async Task<IActionResult> AssignInstructorToStudentAsync([FromQuery, Required] Guid instructorId, [FromQuery, Required] Guid studentId)
    {
        
        var instructor = await _repository.GetByIdAsync(instructorId);
        var student = await _studentRepository.GetByIdAsync(studentId);
        
        instructor.Students.Add(student);
        await _repository.UpdateAsync(instructor);
        
        return Ok();
    }



    [HttpDelete("/instructors/{id:guid}")]
    public async Task<IActionResult> DeleteInstructorByIdAsync(Guid id)
    {
        var instructor = await _repository.GetByIdAsync(id);
        
        await _repository.DeleteAsync(id); 
        return NoContent(); 
    }


}