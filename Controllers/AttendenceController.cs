using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {
        private readonly IAttendence attendenceRepository;

        public AttendenceController(IAttendence attendenceRepository)
        {
            this.attendenceRepository = attendenceRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Attendence>> CreateAttendence(Attendence attendence)
        {
            try
            {
                if (attendence == null)
                    return BadRequest();

                var createdAttendence = await attendenceRepository.AddRecord(attendence);

                return CreatedAtAction(nameof(GetAttendence),
                    new { id = createdAttendence.ID }, createdAttendence);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Attendence>> UpdateAttendence(int id, Attendence attendence)
        {
            try
            {
                if (id != attendence.ID)
                    return BadRequest("Attendence ID mismatch");

                var attendenceToUpdate = await attendenceRepository.GetRecord(id);

                if (attendenceToUpdate == null)
                    return NotFound($"Attendence with Id = {id} not found");

                return await attendenceRepository.UpdateRecord(attendence);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendence>>> GetAppointment()
        {
            try
            {
                return (await attendenceRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Attendence>> GetAttendence(int id)
        {
            try
            {
                var result = await attendenceRepository.GetRecord(id);

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
        public async Task<ActionResult<Attendence>> DeleteAttendence(int id)
        {
            try
            {
                var attendenceToDelete = await attendenceRepository.GetRecord(id);

                if (attendenceToDelete == null)
                {
                    return NotFound($"FamilyDetails with Id = {id} not found");
                }

                return await attendenceRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
