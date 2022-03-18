using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class ExpensesRepository : IExpenses
    {
        private readonly IRMSContext irmsDBContext;

        public ExpensesRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Expenses>> GetAllRecords()
        {
            return await irmsDBContext.Expenses.ToListAsync();
        }

        public async Task<Expenses> GetRecord(int iD)
        {
            return await irmsDBContext.Expenses
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Expenses> AddRecord(Expenses expenses)
        {
            var result = await irmsDBContext.Expenses.AddAsync(expenses);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Expenses> UpdateRecord(Expenses expenses)
        {
            var result = await irmsDBContext.Expenses
                .FirstOrDefaultAsync(e => e.ID == expenses.ID);

            if (result != null)
            {
                // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Expenses> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Expenses
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Expenses.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
