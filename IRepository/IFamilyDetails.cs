using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IFamilyDetails
    {
        Task<IEnumerable<FamilyDetails>> GetAllRecords();
        Task<FamilyDetails> GetRecord(int iD);
        Task<FamilyDetails> AddRecord(FamilyDetails familyDetails);
        Task<FamilyDetails> UpdateRecord(FamilyDetails familyDetails);
        Task<FamilyDetails> DeleteRecord(int iD);
    }
}

