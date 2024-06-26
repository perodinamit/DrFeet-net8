﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Calculation
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; } = decimal.Zero;
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public int? ShoeId { get; set; }
        public Shoe? Shoe { get; set; }
        public List<CalculationItem> CalculationItems { get; set;} = new List<CalculationItem>();
    }
}
