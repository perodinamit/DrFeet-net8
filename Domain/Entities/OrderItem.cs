using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int CalculationId { get; set; }
        public Calculation Calculation { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
    }
}
