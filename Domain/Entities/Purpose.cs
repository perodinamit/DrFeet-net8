using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Purpose
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public Units? Units { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal? ExpensePerUnit { get; set; } = null!;
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
