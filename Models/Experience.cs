namespace IRMS.Models
{
    public class Experience
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public string? Organization { get; set; }
        public string? TechnologiesWorkedOn { get; set; }
        public string? Position { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public DateTime? DateOfRelieving { get; set; }
        public string? LastSalary { get; set; }
        public string? Reason { get; set; }
        public decimal? CTC { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
