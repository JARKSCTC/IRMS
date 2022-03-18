using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class AttendenceRepository : IAttendence
    {
        private readonly IRMSContext irmsDBContext;

        public AttendenceRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Attendence>> GetAllRecords()
        {
            return await irmsDBContext.Attendence.ToListAsync();
        }

        public async Task<Attendence> GetRecord(int iD)
        {
            return await irmsDBContext.Attendence
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Attendence> AddRecord(Attendence attendence)
        {
            var result = await irmsDBContext.Attendence.AddAsync(attendence);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Attendence> UpdateRecord(Attendence attendence)
        {
            var result = await irmsDBContext.Attendence
                .FirstOrDefaultAsync(e => e.ID == attendence.ID);

            if (result != null)
            {
                // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Attendence> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Attendence
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Attendence.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
