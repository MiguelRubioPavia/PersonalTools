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
    [Table("FamilyGroups")]
    public class FamilyGroup : BaseNotifyPropertyChanged
    {
        #region Properties
        private int _FamilyGroupId;
        public int FamilyGroupId
        {
            get => _FamilyGroupId;
            set => SetField(ref _FamilyGroupId, value);
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

        private ICollection<Family> _Families;
        public virtual ICollection<Family> Families
        {
            get => _Families;
            set => SetField(ref _Families, value);
        }
        #endregion

        #region Operators
        public override string ToString() => Code;

        public override bool Equals(object obj)
            => obj != null && obj.GetType().Equals(typeof(FamilyGroup)) && this.FamilyGroupId == ((FamilyGroup)obj).FamilyGroupId;

        public override int GetHashCode() => FamilyGroupId;
        #endregion
    }
}
