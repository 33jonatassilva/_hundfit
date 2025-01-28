using HundFit.Models;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HundFit.Controllers;


[ApiController]
[Route("/physical-assessment")]

public class PhysicalAssessmentController : ControllerBase
{
    
        private readonly IPhysicalAssessmentRepository _repository;

        public PhysicalAssessmentController(IPhysicalAssessmentRepository repository)
        {
            _repository = repository;
        }
    


        [HttpPost("/physical-assessment")]
        public async Task<IActionResult> CreatePhysicalAssessmentAsync([FromBody] PhysicalAssessment physicalAssessment)
        {
            await _repository.CreateAsync(physicalAssessment);
            return Ok(physicalAssessment);
        }
    
    
    
        [HttpGet("/physical-assessment")]
        public async Task<IActionResult> GetPhysicalAssessments()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
    
    
    
        [HttpGet("/physical-assessment/{id:guid}")]
        public async Task<IActionResult> GetPhysicalAssessmentsByIdAsync(Guid id)
        {
            var physicalAssessment = await _repository.GetByIdAsync(id);
            return Ok(physicalAssessment);
        }
    


        /*[HttpPut("/PhysicalAssessments/{id:guid}")]
        public IActionResult UpdatePhysicalAssessment(Guid id, [FromBody] PhysicalAssessment PhysicalAssessment)
        {
            var PhysicalAssessmentToUpdate = _repository.GetPhysicalAssessmentById(id);

            PhysicalAssessmentToUpdate.Name = PhysicalAssessment.Name;
            PhysicalAssessmentToUpdate.Description = PhysicalAssessment.Description;
            PhysicalAssessmentToUpdate.TrainingId = PhysicalAssessment.TrainingId;
            PhysicalAssessmentToUpdate.Load = PhysicalAssessment.Load;
            PhysicalAssessmentToUpdate.Repetitions = PhysicalAssessment.Repetitions;

            _repository.Update(PhysicalAssessmentToUpdate);
            return Ok(PhysicalAssessmentToUpdate);
        }*/



        [HttpDelete("/physical-assessment/{id:guid}")]
        public async Task<IActionResult> DeletePhysicalAssessmentByIdAsync(Guid id)
        {
            var physicalAssessment = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);
            return Ok(physicalAssessment);
        }
}