using System.ComponentModel.DataAnnotations;
using HundFit.Data.Models;
using HundFit.DTOs;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Controllers;



[ApiController]
[Route("/student")]

public class StudentController :ControllerBase
{
    private readonly IStudentRepository _repository;

    public StudentController(IStudentRepository repository)
    {
        _repository = repository;
    }
    
    
    [HttpPost("/student")]
    public async Task<IActionResult> CreateStudentAsync([FromBody] StudentDTO studentDto)
    {

        var student = new Student
        {
            PlanId = studentDto.PlanId,
            InstructorId = studentDto.InstructorId,
            TrainingId = studentDto.TrainingId,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            BirthDate = studentDto.BirthDate,
            Email = studentDto.Email,
            PhoneNumber = studentDto.PhoneNumber,
            Address = studentDto.Address
        };
        
        await _repository.CreateAsync(student);
        return Ok(student);
    }

    [HttpPost("/student/plan/{planId:guid}")]
    public async Task<IActionResult> AddStudentToPlanAsync([FromQuery] Guid? id, [FromRoute] Guid planId, [FromBody] StudentDTO? studentDto)
    {
        
        if (id.HasValue)
        {
            var student = await _repository.GetByIdAsync(id.Value);
            student.PlanId = planId;
            student.Plan.Students.Add(student);
            await _repository.UpdateAsync(student);
            return Ok(student);
        }

        var studentTwo = new Student
        {
            Id = Guid.NewGuid(),
            PlanId = planId,
            InstructorId = studentDto.InstructorId,
            TrainingId = studentDto.TrainingId,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            BirthDate = studentDto.BirthDate,
            Email = studentDto.Email,
            PhoneNumber = studentDto.PhoneNumber,
            Address = studentDto.Address,
            RegistrationDate = studentDto.RegistrationDate
        };
        
        await _repository.CreateAsync(studentTwo);
        return Ok(studentTwo);

    }



    [HttpGet("/student/")]
    public async Task<IActionResult> GetStudentsAsync([FromQuery] Guid? id)
    {
        return id.HasValue ? Ok(await _repository.GetByIdAsync(id.Value)) : Ok(await _repository.GetAllAsync());
    }

    [HttpGet("/student/student-stats")]

    public async Task<IActionResult> GetStudentStatsAsync([FromQuery, Required] Guid id)
    {
        var student = await _repository.GetByIdWithStudentStatsAsync(id);
        
        var studentStats = student.StudentStats.Select(x => x);
        
        return Ok(studentStats);
        

    }
    
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetStudentsAsync()
    {
        var students = await _repository.GetAllAsync();
        return Ok(students);
    }
    
    
    
    [SwaggerIgnore]
    public async Task<IActionResult> GetStudentsByIdAsync(Guid id)
    {
        var student = await _repository.GetByIdAsync(id);
        return Ok(student);
    }
    


    [HttpPut("/students/{id:guid}")]
    public async Task<IActionResult> UpdateStudentAsync(Guid id, [FromBody] UpdateStudentDTO studentDto)
    {
        var student = await _repository.GetByIdAsync(id);
        
       student.PlanId = studentDto.PlanId;
       student.InstructorId = studentDto.InstructorId;
       student.TrainingId = studentDto.TrainingId;
       student.FirstName = studentDto.FirstName;
       student.LastName = studentDto.LastName;
       student.BirthDate = studentDto.BirthDate;
       student.Email = studentDto.Email;
       student.PhoneNumber = studentDto.PhoneNumber;
       student.Address = studentDto.Address;

        await _repository.UpdateAsync(student);
        return Ok(student);
    }



    [HttpDelete("/student/{id:guid}")]
    public async Task<IActionResult> DeleteStudentByIdAsync(Guid id)
    {
        var student = _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}