using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperience experienceRepository;

        public ExperienceController(IExperience experienceRepository)
        {
            this.experienceRepository = experienceRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> CreateExperience(Experience experience)
        {
            try
            {
                if (experience == null)
                    return BadRequest();

                var createdExperience = await experienceRepository.AddRecord(experience);

                return CreatedAtAction(nameof(GetExperience),
                    new { id = createdExperience.ID }, createdExperience);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Experience>> UpdateExperience(int id, Experience experience)
        {
            try
            {
                if (id != experience.ID)
                    return BadRequest("Experience ID mismatch");

                var experienceToUpdate = await experienceRepository.GetRecord(id);

                if (experienceToUpdate == null)
                    return NotFound($"Experience with Id = {id} not found");

                return await experienceRepository.UpdateRecord(experience);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperience()
        {
            try
            {
                return (await experienceRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Experience>> GetExperience(int id)
        {
            try
            {
                var result = await experienceRepository.GetRecord(id);

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
        public async Task<ActionResult<Experience>> DeleteExperience(int id)
        {
            try
            {
                var experienceToDelete = await experienceRepository.GetRecord(id);

                if (experienceToDelete == null)
                {
                    return NotFound($"Experience with Id = {id} not found");
                }

                return await experienceRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
