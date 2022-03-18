using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IExperience
    {
        Task<IEnumerable<Experience>> GetAllRecords();
        Task<Experience> GetRecord(int iD);
        Task<Experience> AddRecord(Experience experience);
        Task<Experience> UpdateRecord(Experience experience);
        Task<Experience> DeleteRecord(int iD);
    }
}

