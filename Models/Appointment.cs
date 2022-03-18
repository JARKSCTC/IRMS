namespace IRMS.Models
{
    public class Appointment
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public string? RefNumber { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string? Designation { get; set; }
        public string? GroupCategory { get; set; }
        public string? Location { get; set; }
        public decimal? CTC { get; set; }
        public string? CTCinWords { get; set; }
        public string? ReportingTo { get; set; }
        public DateTime? ReportingTime { get; set; }
        public string? ReportingMailID { get; set; }
        public string? CompanyName { get; set; }
        public string? ModeOfPayment { get; set; }
        public decimal? NetSalary { get; set; }
        public decimal? GrossDeductions { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
