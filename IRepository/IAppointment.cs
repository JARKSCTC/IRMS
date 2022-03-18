using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IAppointment
    {
        Task<IEnumerable<Appointment>> GetAllRecords();
        Task<Appointment> GetRecord(int iD);
        Task<Appointment> AddRecord(Appointment appointment);
        Task<Appointment> UpdateRecord(Appointment Appointment);
        Task<Appointment> DeleteRecord(int iD);
    }
}

