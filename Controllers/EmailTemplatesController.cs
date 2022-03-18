using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTemplatesController : ControllerBase
    {
        private readonly IEmailTemplates emailTemplatesRepository;

        public EmailTemplatesController(IEmailTemplates emailTemplatesRepository)
        {
            this.emailTemplatesRepository = emailTemplatesRepository;
        }

        [HttpPost]
        public async Task<ActionResult<EmailTemplates>> CreateEmailTemplates(EmailTemplates emailTemplates)
        {
            try
            {
                if (emailTemplates == null)
                    return BadRequest();

                var createdEmailTemplates = await emailTemplatesRepository.AddRecord(emailTemplates);

                return CreatedAtAction(nameof(GetEmailTemplates),
                    new { id = createdEmailTemplates.ID }, createdEmailTemplates);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmailTemplates>> UpdateEmailTemplates(int id, EmailTemplates emailTemplates)
        {
            try
            {
                if (id != emailTemplates.ID)
                    return BadRequest("EmailTemplates ID mismatch");

                var emailTemplatesToUpdate = await emailTemplatesRepository.GetRecord(id);

                if (emailTemplatesToUpdate == null)
                    return NotFound($"EmailTemplates with Id = {id} not found");

                return await emailTemplatesRepository.UpdateRecord(emailTemplates);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailTemplates>>> GetEmailTemplates()
        {
            try
            {
                return (await emailTemplatesRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmailTemplates>> GetEmailTemplates(int id)
        {
            try
            {
                var result = await emailTemplatesRepository.GetRecord(id);

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
        public async Task<ActionResult<EmailTemplates>> DeleteEmailTemplates(int id)
        {
            try
            {
                var emailTemplatesToDelete = await emailTemplatesRepository.GetRecord(id);

                if (emailTemplatesToDelete == null)
                {
                    return NotFound($"EmailTemplates with Id = {id} not found");
                }

                return await emailTemplatesRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
