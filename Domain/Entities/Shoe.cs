using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Shoe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public DateTime AddedOn { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(6,2)")]
        public decimal? Price { get; set; } = decimal.Zero;
        public byte[]? ImageData { get; set; }

        public int TopId { get; set; }
        public Top? Top { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal? TopCoeficient { get; set; }

        public int ColorTypeId { get; set; }
        public ColorType? ColorType { get; set; }

        public int LiningId { get; set; }
        public Lining? Lining { get; set;}
        [Column(TypeName = "decimal(6,2)")]
        public decimal? LiningCoeficient { get; set; }

        public int PurposeId { get; set; }
        public Purpose? Purpose { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal? PurposeCoeficient { get; set; }

        public int SoleId { get; set; }
        public Sole? Sole { get; set;}
        [Column(TypeName = "decimal(6,2)")]
        public decimal? SoleCoeficient { get; set; }

        public int? DecorationId { get; set; }
        public Decoration? Decoration { get; set; }

        public List<Calculation>? Calculations { get; set; }
    }
}
