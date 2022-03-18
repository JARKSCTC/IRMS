using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class ExperienceRepository : IExperience
    {
        private readonly IRMSContext irmsDBContext;

        public ExperienceRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Experience>> GetAllRecords()
        {
            return await irmsDBContext.Experience.ToListAsync();
        }

        public async Task<Experience> GetRecord(int iD)
        {
            return await irmsDBContext.Experience
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Experience> AddRecord(Experience experience)
        {
            var result = await irmsDBContext.Experience.AddAsync(experience);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Experience> UpdateRecord(Experience experience)
        {
            var result = await irmsDBContext.Experience
                .FirstOrDefaultAsync(e => e.ID == experience.ID);

            if (result != null)
            {
                // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Experience> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Experience
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Experience.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
