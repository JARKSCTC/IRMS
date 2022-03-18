using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class FamilyDetailsRepository : IFamilyDetails
    {
        private readonly IRMSContext irmsDBContext;

        public FamilyDetailsRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<FamilyDetails>> GetAllRecords()
        {
            return await irmsDBContext.FamilyDetails.ToListAsync();
        }

        public async Task<FamilyDetails> GetRecord(int iD)
        {
            return await irmsDBContext.FamilyDetails
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<FamilyDetails> AddRecord(FamilyDetails familyDetails)
        {
            var result = await irmsDBContext.FamilyDetails.AddAsync(familyDetails);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FamilyDetails> UpdateRecord(FamilyDetails familyDetails)
        {
            var result = await irmsDBContext.FamilyDetails
                .FirstOrDefaultAsync(e => e.ID == familyDetails.ID);

            if (result != null)
            {
                // Add Later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<FamilyDetails> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.FamilyDetails
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.FamilyDetails.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
