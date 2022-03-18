namespace IRMS.Models
{
    public class Address
    {
        public int? ID { get; set; }
        public string? AddressID { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int? PostalCode { get; set; }
        public bool? AddressType { get; set; }
        public string? EmployeeID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
