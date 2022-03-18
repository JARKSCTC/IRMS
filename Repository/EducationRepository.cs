using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class EducationRepository : IEducation
    {
        private readonly IRMSContext irmsDBContext;

        public EducationRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Education>> GetAllRecords()
        {
            return await irmsDBContext.Education.ToListAsync();
        }

        public async Task<Education> GetRecord(int iD)
        {
            return await irmsDBContext.Education
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Education> AddRecord(Education education)
        {
            var result = await irmsDBContext.Education.AddAsync(education);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Education> UpdateRecord(Education education)
        {
            var result = await irmsDBContext.Education
                .FirstOrDefaultAsync(e => e.ID == education.ID);

            if (result != null)
            {
             // I will add education details later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Education> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Education
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Education.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
