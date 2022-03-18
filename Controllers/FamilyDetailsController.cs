using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyDetailsController : ControllerBase
    {
        private readonly IFamilyDetails familyDetailsRepository;

        public FamilyDetailsController(IFamilyDetails familyDetailsRepository)
        {
            this.familyDetailsRepository = familyDetailsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<FamilyDetails>> CreateFamilyDetails(FamilyDetails familyDetails)
        {
            try
            {
                if (familyDetails == null)
                    return BadRequest();

                var createdFamilyDetails = await familyDetailsRepository.AddRecord(familyDetails);

                return CreatedAtAction(nameof(GetFamilyDetails),
                    new { id = createdFamilyDetails.ID }, createdFamilyDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<FamilyDetails>> UpdateFamilyDetails(int id, FamilyDetails familyDetails)
        {
            try
            {
                if (id != familyDetails.ID)
                    return BadRequest("FamilyDetails ID mismatch");

                var familyDetailsToUpdate = await familyDetailsRepository.GetRecord(id);

                if (familyDetailsToUpdate == null)
                    return NotFound($"FamilyDetails with Id = {id} not found");

                return await familyDetailsRepository.UpdateRecord(familyDetails);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyDetails>>> GetFamilyDetails()
        {
            try
            {
                return (await familyDetailsRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FamilyDetails>> GetFamilyDetails(int id)
        {
            try
            {
                var result = await familyDetailsRepository.GetRecord(id);

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
        public async Task<ActionResult<FamilyDetails>> DeleteFamilyDetails(int id)
        {
            try
            {
                var familyDetailsToDelete = await familyDetailsRepository.GetRecord(id);

                if (familyDetailsToDelete == null)
                {
                    return NotFound($"FamilyDetails with Id = {id} not found");
                }

                return await familyDetailsRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
