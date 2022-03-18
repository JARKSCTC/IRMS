using IRMS.IRepository;
using IRMS.Models;
using IRMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddress addressRepository;

        public AddressController(IAddress addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
            try
            {
                if (address == null)
                    return BadRequest();

                var createdAddress = await addressRepository.AddRecord(address);

                return CreatedAtAction(nameof(GetAddress),
                    new { id = createdAddress.ID }, createdAddress);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Address>> UpdateAddress(int id, Address address)
        {
            try
            {
                if (id != address.ID)
                    return BadRequest("Address ID mismatch");

                var addressToUpdate = await addressRepository.GetRecord(id);

                if (addressToUpdate == null)
                    return NotFound($"Address with Id = {id} not found");

                return await addressRepository.UpdateRecord(address);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            try
            {
                return (await addressRepository.GetAllRecords()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            try
            {
                var result = await addressRepository.GetRecord(id);

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
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            try
            {
                var addressToDelete = await addressRepository.GetRecord(id);

                if (addressToDelete == null)
                {
                    return NotFound($"Address with Id = {id} not found");
                }

                return await addressRepository.DeleteRecord(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
