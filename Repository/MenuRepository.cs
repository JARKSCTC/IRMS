using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class MenuRepository : IMenu
    {
        private readonly IRMSContext irmsDBContext;

        public MenuRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Menu>> GetAllRecords()
        {
            return await irmsDBContext.Menu.ToListAsync();
        }

        public async Task<Menu> GetRecord(int iD)
        {
            return await irmsDBContext.Menu
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Menu> AddRecord(Menu menu)
        {
            var result = await irmsDBContext.Menu.AddAsync(menu);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Menu> UpdateRecord(Menu menu)
        {
            var result = await irmsDBContext.Menu
                .FirstOrDefaultAsync(e => e.ID == menu.ID);

            if (result != null)
            {
                // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Menu> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Menu
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Menu.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
