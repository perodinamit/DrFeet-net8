using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Miscellaneous
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal? Price { get; set; }
        public Units? Units { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal? ExpensePerUnit { get; set; } = null!;
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
