using Core.BaseClasses;
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
    public class SubFamily : BaseNotifyPropertyChanged
    {
        #region Properties
        private int _SubFamilyId;
        public int SubFamilyId
        {
            get => _SubFamilyId;
            set => SetField(ref _SubFamilyId, value);
        }

        private string _Code;
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Code
        {
            get => _Code;
            set => SetField(ref _Code, value);
        }

        private int _FamilyId;
        public int FamilyId
        {
            get => _FamilyId;
            set => SetField(ref _FamilyId, value);
        }

        private Family _Family;
        public virtual Family Family
        {
            get => _Family;
            set => SetField(ref _Family, value);
        }

        private ICollection<FinanceMovement> _FinanceMovements;
        public virtual ICollection<FinanceMovement> FinanceMovements
        {
            get => _FinanceMovements;
            set => SetField(ref _FinanceMovements, value);
        }
        #endregion
    }
}
