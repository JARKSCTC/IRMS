using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IAttendence
    {
        Task<IEnumerable<Attendence>> GetAllRecords();
        Task<Attendence> GetRecord(int iD);
        Task<Attendence> AddRecord(Attendence attendence);
        Task<Attendence> UpdateRecord(Attendence attendence);
        Task<Attendence> DeleteRecord(int iD);
    }
}

