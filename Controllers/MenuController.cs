using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenu menuRepository;

        public MenuController(IMenu menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> CreateMenu(Menu menu)
        {
            try
            {
                if (menu == null)
                    return BadRequest();

                var createdMenu = await menuRepository.AddRecord(menu);

                return CreatedAtAction(nameof(GetMenu),
                    new { id = createdMenu.ID }, createdMenu);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Menu>> UpdateMenu(int id, Menu menu)
        {
            try
            {
                if (id != menu.ID)
                    return BadRequest("Menu ID mismatch");

                var menuToUpdate = await menuRepository.GetRecord(id);

                if (menuToUpdate == null)
                    return NotFound($"Menu with Id = {id} not found");

                return await menuRepository.UpdateRecord(menu);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenu()
        {
            try
            {
                return (await menuRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            try
            {
                var result = await menuRepository.GetRecord(id);

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
        public async Task<ActionResult<Menu>> DeleteMenu(int id)
        {
            try
            {
                var menuToDelete = await menuRepository.GetRecord(id);

                if (menuToDelete == null)
                {
                    return NotFound($"Menu with Id = {id} not found");
                }

                return await menuRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
