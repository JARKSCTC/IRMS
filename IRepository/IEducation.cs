using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IEducation
    {
        Task<IEnumerable<Education>> GetAllRecords();
        Task<Education> GetRecord(int iD);
        Task<Education> AddRecord(Education education);
        Task<Education> UpdateRecord(Education education);
        Task<Education> DeleteRecord(int iD);
    }
}

