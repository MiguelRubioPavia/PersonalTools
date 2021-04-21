using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("FinanceMovements")]
    public class FinanceMovement
    {
        public int FinanceMovementId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Concept { get; set; }
        public string Comment { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public bool IsBreakdown { get; set; }
        public int SubFamilyId { get; set; }
        public SubFamily SubFamily { get; set; }
        public int? BreakDownId { get; set; }
        public FinanceMovement BreakDown { get; set; }
        public ICollection<FinanceMovement> BreakDownDetails { get; set; }
    }
}
