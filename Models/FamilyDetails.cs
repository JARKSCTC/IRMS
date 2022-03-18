namespace IRMS.Models
{
    public class FamilyDetails
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public string? Relationship { get; set; }
        public string? PersonName { get; set; }
        public string? Occupation { get; set; }
        public int? Age { get; set; }
        public decimal? Income { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
