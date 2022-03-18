using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllRecords();
        Task<Employee> GetRecord(int iD);
        Task<Employee> AddRecord(Employee employee);
        Task<Employee> UpdateRecord(Employee employee);
        Task<Employee> DeleteRecord(int iD);
    }
}

