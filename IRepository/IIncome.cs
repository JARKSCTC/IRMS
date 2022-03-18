using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IIncome
    {
        Task<IEnumerable<Income>> GetAllRecords();
        Task<Income> GetRecord(int iD);
        Task<Income> AddRecord(Income income);
        Task<Income> UpdateRecord(Income income);
        Task<Income> DeleteRecord(int iD);
    }
}

