using HundFit.Data.Models;
using HundFit.Repositories.Interfaces;
using HundFit.ModelsDTOs;
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
            Id = Guid.NewGuid(),
            PlanId = studentDto.PlanId,
            InstructorId = studentDto.InstructorId,
            TrainingId = studentDto.TrainingId,
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            BirthDate = studentDto.BirthDate,
            Email = studentDto.Email,
            PhoneNumber = studentDto.PhoneNumber,
            Address = studentDto.Address,
            RegistrationDate = studentDto.RegistrationDate,
        };
        
        await _repository.CreateAsync(student);
        return Ok(student);
    }

    /*[HttpPost("/student/plan/{planId:guid}")]
    public async Task<IActionResult> AddStudentToPlanAsync([FromQuery] Guid? id, [FromRoute] Guid planId, [FromBody] Student? studentToAdd)
    {
        
        if (id.HasValue)
        {
            var student = await _repository.GetByIdAsync(id.Value);
            student.PlanId = planId;
            student.Plan.Students.Add(student);
            await _repository.UpdateAsync(student);
            return Ok(student);
        }
        
        studentToAdd.PlanId = planId;
        studentToAdd.Plan.Students.Add(studentToAdd);
        await _repository.UpdateAsync(studentToAdd);
        return Ok(studentToAdd);
        
    }*/



    [HttpGet("/student/")]
    public async Task<IActionResult> GetStudentsAsync([FromQuery] Guid? id)
    {
        return id.HasValue ? Ok(await _repository.GetByIdAsync(id.Value)) : Ok(await _repository.GetAllAsync());
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
    


    /*[HttpPut("/students/{id:guid}")]
    public IActionResult Updatestudent(Guid id, [FromBody] student student)
    {
        var studentToUpdate = _repository.GetstudentById(id);

        studentToUpdate.Name = student.Name;
        studentToUpdate.Description = student.Description;
        studentToUpdate.TrainingId = student.TrainingId;
        studentToUpdate.Load = student.Load;
        studentToUpdate.Repetitions = student.Repetitions;

        _repository.Update(studentToUpdate);
        return Ok(studentToUpdate);
    }*/



    [HttpDelete("/student/{id:guid}")]
    public async Task<IActionResult> DeleteStudentByIdAsync(Guid id)
    {
        var student = _repository.GetByIdAsync(id);
        _repository.DeleteAsync(id);
        return Ok(student);
    }
}