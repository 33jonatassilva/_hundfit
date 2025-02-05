using System.ComponentModel.DataAnnotations;
using HundFit.Data.Models;
using HundFit.DTOs;
using HundFit.Repositories;
using HundFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HundFit.Controllers;


[ApiController]
[Route("/plan")]

public class PlanController : ControllerBase
{
        
    
        private readonly IPlanRepository _repository;

        public PlanController(IPlanRepository repository)
        {
            _repository = repository;
        }
    
        
        
        [HttpPost("/plan")]
        public async Task<IActionResult> CreatePlanAsync([FromBody] PlanDTO planDto)
        {

            var plan = new Plan
            {
                Name = planDto.Name,
                Price = planDto.Price,
                DurationInMonths = planDto.DurationInMonths
            };
            
            
            await _repository.CreateAsync(plan);
            return Ok(plan);
        }



        [HttpGet("/plan/")]
        public async Task<IActionResult> GetPlanAsync([FromQuery] Guid? id)
        {
            return id.HasValue ? Ok(await _repository.GetByIdAsync(id.Value)) : Ok(await _repository.GetAllAsync());
        }
        
        
        [SwaggerIgnore]
        public async Task<IActionResult> GetPlansAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
    
    
    
        [SwaggerIgnore]
        public async Task<IActionResult> GetPlansByIdAsync(Guid id)
        {
            var plan = await _repository.GetByIdAsync(id);
            return Ok(plan);
        }


        [HttpGet("/plan/students")]

        public async Task<IActionResult> GetPlanStudentsAsync([FromQuery, Required] Guid id)
        {
            var plan = await _repository.GetByIdWithStudentsAsync(id);
            
            var students = plan.Students.Select(s => new StudentDTO
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
                }
                ).ToList();
            
            return Ok(students);
        }
    


        [HttpPut("/Plans/{id:guid}")]
        public async Task<IActionResult> UpdatePlan(Guid id, [FromBody] PlanDTO planDto)
        {
            var plan = await _repository.GetByIdAsync(id);

            plan.Name = planDto.Name;
            plan.Price = planDto.Price;
            plan.DurationInMonths = planDto.DurationInMonths;
           
            await _repository.UpdateAsync(plan);
            return Ok(plan);
        }



        [HttpDelete("/plan/{id:guid}")]
        public async Task<IActionResult> DeletePlanByIdAsync(Guid id)
        {
            var plan = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);
            return NoContent();
        }


}