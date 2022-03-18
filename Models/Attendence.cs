namespace IRMS.Models
{
    public class Attendence
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public bool? Present { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string? Reason { get; set; }
        public bool? LeaveType { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
