using HundFit.Models;
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
    public async Task<IActionResult> CreateStudentAsync([FromBody] Student student)
    {
        await _repository.CreateAsync(student);
        return Ok(student);
    }



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