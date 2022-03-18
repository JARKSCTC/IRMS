using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IExpenses
    {
        Task<IEnumerable<Expenses>> GetAllRecords();
        Task<Expenses> GetRecord(int iD);
        Task<Expenses> AddRecord(Expenses expenses);
        Task<Expenses> UpdateRecord(Expenses expenses);
        Task<Expenses> DeleteRecord(int iD);
    }
}

