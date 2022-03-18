using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment appointmentRepository;

        public AppointmentController(IAppointment appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                    return BadRequest();

                var createdAppointment = await appointmentRepository.AddRecord(appointment);

                return CreatedAtAction(nameof(GetAppointment),
                    new { id = createdAppointment.ID }, createdAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int id, Appointment appointment)
        {
            try
            {
                if (id != appointment.ID)
                    return BadRequest("Appointment ID mismatch");

                var appointmentToUpdate = await appointmentRepository.GetRecord(id);

                if (appointmentToUpdate == null)
                    return NotFound($"Appointment with Id = {id} not found");

                return await appointmentRepository.UpdateRecord(appointment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        {
            try
            {
                return (await appointmentRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            try
            {
                var result = await appointmentRepository.GetRecord(id);

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
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            try
            {
                var appointmentToDelete = await appointmentRepository.GetRecord(id);

                if (appointmentToDelete == null)
                {
                    return NotFound($"Appointment with Id = {id} not found");
                }

                return await appointmentRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
