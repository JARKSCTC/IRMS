using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducation educationRepository;

        public EducationController(IEducation educationRepository)
        {
            this.educationRepository = educationRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Education>> CreateEducation(Education education)
        {
            try
            {
                if (education == null)
                    return BadRequest();

                var createdEducation = await educationRepository.AddRecord(education);

                return CreatedAtAction(nameof(GetEducation),
                    new { id = createdEducation.ID }, createdEducation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Education>> UpdateEducation(int id, Education education)
        {
            try
            {
                if (id != education.ID)
                    return BadRequest("Education ID mismatch");

                var educationToUpdate = await educationRepository.GetRecord(id);

                if (educationToUpdate == null)
                    return NotFound($"Address with Id = {id} not found");

                return await educationRepository.UpdateRecord(education);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducation()
        {
            try
            {
                return (await educationRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
            try
            {
                var result = await educationRepository.GetRecord(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Education>> DeleteEducation(int id)
        {
            try
            {
                var educationToDelete = await educationRepository.GetRecord(id);

                if (educationToDelete == null)
                {
                    return NotFound($"Education with Id = {id} not found");
                }

                return await educationRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
