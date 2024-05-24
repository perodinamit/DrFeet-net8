namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<OrderItem> OrderItems { get; set; } = [];
        public int TotalOrderQuantaty { get; set; }
        public DateTime? OrderDate { get; set; } = null;
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
