using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("FamilyGroups")]
    public class FamilyGroup
    {
        public int FamilyGroupId { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Code { get; set; }
        public ICollection<Family> Families { get; set; }
    }
}
