using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenses expensesRepository;

        public ExpensesController(IExpenses expensesRepository)
        {
            this.expensesRepository = expensesRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Expenses>> CreateExpenses(Expenses expenses)
        {
            try
            {
                if (expenses == null)
                    return BadRequest();

                var createdExpenses = await expensesRepository.AddRecord(expenses);

                return CreatedAtAction(nameof(GetExpenses),
                    new { id = createdExpenses.ID }, createdExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Expenses>> UpdateExpenses(int id, Expenses expenses)
        {
            try
            {
                if (id != expenses.ID)
                    return BadRequest("Expenses ID mismatch");

                var expensesToUpdate = await expensesRepository.GetRecord(id);

                if (expensesToUpdate == null)
                    return NotFound($"Expenses with Id = {id} not found");

                return await expensesRepository.UpdateRecord(expenses);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expenses>>> GetExpenses()
        {
            try
            {
                return (await expensesRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Expenses>> GetExpenses(int id)
        {
            try
            {
                var result = await expensesRepository.GetRecord(id);

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
        public async Task<ActionResult<Expenses>> DeleteExpenses(int id)
        {
            try
            {
                var expensesToDelete = await expensesRepository.GetRecord(id);

                if (expensesToDelete == null)
                {
                    return NotFound($"Expenses with Id = {id} not found");
                }

                return await expensesRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
