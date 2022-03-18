namespace IRMS.Models
{
    public class Education
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public string? InstituteName { get; set; }
        public string? School_College { get; set; }
        public string? Class_Degree { get; set; }
        public string? Place { get; set; }
        public decimal? Securing { get; set; }
        public int? PassOut { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
