namespace IRMS.Models
{
    public class EmailTemplates
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public int? EmailType { get; set; }
        public string? Template { get; set; }
        public string? PlaceHolders { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
