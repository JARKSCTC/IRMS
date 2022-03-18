using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IMenu
    {
        Task<IEnumerable<Menu>> GetAllRecords();
        Task<Menu> GetRecord(int iD);
        Task<Menu> AddRecord(Menu menu);
        Task<Menu> UpdateRecord(Menu menu);
        Task<Menu> DeleteRecord(int iD);
    }
}

