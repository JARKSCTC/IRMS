using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class AddressRepository : IAddress
    {
        private readonly IRMSContext irmsDBContext;

        public AddressRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Address>> GetAllRecords()
        {
            return await irmsDBContext.Address.ToListAsync();
        }

        public async Task<Address> GetRecord(int iD)
        {
            return await irmsDBContext.Address
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Address> AddRecord(Address address)
        {
            var result = await irmsDBContext.Address.AddAsync(address);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Address> UpdateRecord(Address address)
        {
            var result = await irmsDBContext.Address
                .FirstOrDefaultAsync(e => e.ID == address.ID);

            if (result != null)
            {
              // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Address> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Address
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Address.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
