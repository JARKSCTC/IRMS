namespace IRMS.Models
{
    public class Employee
    {
        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public string? Gender { get; set; }
        public string? DOB { get; set; }
        public string? Status { get; set; }
        public int? Mobile { get; set; }
        public int? Telephone { get; set; }
        public string? EmailID { get; set; }
        public string? AltEmailID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
