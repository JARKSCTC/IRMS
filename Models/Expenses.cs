namespace IRMS.Models
{
    public class Expenses
    {
        public int? ID { get; set; }
        public int? EmployeeID { get; set; }
        public string? ExpenseType { get; set; }
        public string? Name { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? ItemDate { get; set; }
        public string? EnteredBy { get; set; }
        public string? ToWhom { get; set; }
        public bool? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
