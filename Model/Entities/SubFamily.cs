using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("SubFamilies")]
    public class SubFamily
    {
        public int SubFamilyId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Code { get; set; }
        public int FamilyId { get; set; }
        public Family Family { get; set; }
        public ICollection<FinanceMovement> FinanceMovements { get; set; }
    }
}
