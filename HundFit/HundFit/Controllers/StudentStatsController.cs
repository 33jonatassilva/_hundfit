using HundFit.Data.Models;
using HundFit.DTOs;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Controllers;


[ApiController]
[Route("/physical-assessment")]

public class StudentStatsController : ControllerBase
{
    
        private readonly IStudentStatsRepository _repository;

        public StudentStatsController(IStudentStatsRepository repository)
        {
            _repository = repository;
        }
    


        [HttpPost("/student-stats")]
        public async Task<IActionResult> CreateStudentStatsAsync([FromBody] CreateStudentStatsDTO studentStatsDto)
        {
            var studentStats = new StudentStats()
            {
                StudentId = studentStatsDto.StudentId,
                InstructorId = studentStatsDto.InstructorId,
                FatBody = studentStatsDto.FatBody,
                LeanMass = studentStatsDto.LeanMass,
                CurrentWeight = studentStatsDto.CurrentWeight
            };
            
            await _repository.CreateAsync(studentStats);
            return Ok(studentStatsDto);
        }



        [HttpGet("/student-stats")]


        public async Task<IActionResult> GetStudentStatsAsync([FromQuery] Guid? id)
        {
           return id.HasValue ? Ok(await _repository.GetByIdAsync(id.Value)) : Ok(await _repository.GetAllAsync());
        }
        
        
        [SwaggerIgnore]
        public async Task<IActionResult> GetStudentStats()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
    
    
    
        [SwaggerIgnore]
        public async Task<IActionResult> GetStudentStatsByIdAsync(Guid id)
        {
            var studentStats = await _repository.GetByIdAsync(id);
            return Ok(studentStats);
        }
    


        [HttpPut("/student-stats/{id:guid}")]
        public async Task<IActionResult> UpdateStudentStats(Guid id, [FromBody] StudentStatsDTO studentStatsDto)
        {
            var studentStats = await _repository.GetByIdAsync(id);

            studentStats.StudentId = studentStatsDto.StudentId;
            studentStats.InstructorId = studentStatsDto.InstructorId;
            studentStats.PhysicalAssessmentDate = studentStatsDto.PhysicalAssessmentDate;
            studentStats.FatBody = studentStatsDto.FatBody;
            studentStats.LeanMass = studentStatsDto.LeanMass;
            studentStats.CurrentWeight = studentStatsDto.CurrentWeight;

            await _repository.UpdateAsync(studentStats);
            return Ok(studentStats);
        }



        [HttpDelete("/student-stats/{id:guid}")]
        public async Task<IActionResult> DeleteStudentStatsByIdAsync(Guid id)
        {
            var studentStats = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);
            return NoContent();
        }
}