using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class EmailTemplatesRepository : IEmailTemplates
    {
        private readonly IRMSContext irmsDBContext;

        public EmailTemplatesRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<EmailTemplates>> GetAllRecords()
        {
            return await irmsDBContext.EmailTemplates.ToListAsync();
        }

        public async Task<EmailTemplates> GetRecord(int iD)
        {
            return await irmsDBContext.EmailTemplates
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<EmailTemplates> AddRecord(EmailTemplates emailTemplates)
        {
            var result = await irmsDBContext.EmailTemplates.AddAsync(emailTemplates);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EmailTemplates> UpdateRecord(EmailTemplates emailTemplates)
        {
            var result = await irmsDBContext.EmailTemplates
                .FirstOrDefaultAsync(e => e.ID == emailTemplates.ID);

            if (result != null)
            {
                // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<EmailTemplates> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.EmailTemplates
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.EmailTemplates.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
