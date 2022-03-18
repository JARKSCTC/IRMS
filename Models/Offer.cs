namespace IRMS.Models
{
    public class Offer
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public int? RefNo { get; set; }
        public string? Description { get; set; }
        public DateTime? DOJ { get; set; }
        public string? Designation { get; set; }
        public decimal? CTC { get; set; }
        public string? ReportingTo { get; set; }
        public string? Department { get; set; }
        public DateTime? ReportingDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
