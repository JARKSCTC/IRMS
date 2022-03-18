using IRMS.Models;

namespace IRMS.IRepository
{
    public interface IEmailTemplates
    {
        Task<IEnumerable<EmailTemplates>> GetAllRecords();
        Task<EmailTemplates> GetRecord(int iD);
        Task<EmailTemplates> AddRecord(EmailTemplates emailTemplates);
        Task<EmailTemplates> UpdateRecord(EmailTemplates emailTemplates);
        Task<EmailTemplates> DeleteRecord(int iD);
    }
}

