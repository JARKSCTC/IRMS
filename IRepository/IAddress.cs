using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IAddress
    {
        Task<IEnumerable<Address>> GetAllRecords();
        Task<Address> GetRecord(int iD);
        Task<Address> AddRecord(Address address);
        Task<Address> UpdateRecord(Address address);
        Task<Address> DeleteRecord(int iD);
    }
}

