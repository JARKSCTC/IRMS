namespace IRMS.Models
{
    public class Menu
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
