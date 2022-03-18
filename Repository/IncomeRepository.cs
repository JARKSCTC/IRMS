using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class IncomeRepository : IIncome
    {
        private readonly IRMSContext irmsDBContext;

        public IncomeRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Income>> GetAllRecords()
        {
            return await irmsDBContext.Income.ToListAsync();
        }

        public async Task<Income> GetRecord(int iD)
        {
            return await irmsDBContext.Income
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Income> AddRecord(Income income)
        {
            var result = await irmsDBContext.Income.AddAsync(income);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Income> UpdateRecord(Income income)
        {
            var result = await irmsDBContext.Income
                .FirstOrDefaultAsync(e => e.ID == income.ID);

            if (result != null)
            {
                // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Income> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Income
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Income.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
