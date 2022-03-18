using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncome incomeRepository;

        public IncomeController(IIncome incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Income>> CreateIncome(Income income)
        {
            try
            {
                if (income == null)
                    return BadRequest();

                var createdIncome = await incomeRepository.AddRecord(income);

                return CreatedAtAction(nameof(GetIncome),
                    new { id = createdIncome.ID }, createdIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Income>> UpdateIncome(int id, Income income)
        {
            try
            {
                if (id != income.ID)
                    return BadRequest("Income ID mismatch");

                var incomeToUpdate = await incomeRepository.GetRecord(id);

                if (incomeToUpdate == null)
                    return NotFound($"Income with Id = {id} not found");

                return await incomeRepository.UpdateRecord(income);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncome()
        {
            try
            {
                return (await incomeRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            try
            {
                var result = await incomeRepository.GetRecord(id);

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
        public async Task<ActionResult<Income>> DeleteIncome(int id)
        {
            try
            {
                var incomeToDelete = await incomeRepository.GetRecord(id);

                if (incomeToDelete == null)
                {
                    return NotFound($"Income with Id = {id} not found");
                }

                return await incomeRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
