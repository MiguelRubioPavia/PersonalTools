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
    [Table("Families")]
    public class Family : BaseNotifyPropertyChanged
    {
        #region Properties
        private int _FamilyId;
        public int FamilyId
        {
            get => _FamilyId;
            set => SetField(ref _FamilyId, value);
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

        private int _FamilyGroupId;
        public int FamilyGroupId
        {
            get => _FamilyGroupId;
            set => SetField(ref _FamilyGroupId, value);
        }

        private FamilyGroup _FamilyGroup;
        public virtual FamilyGroup FamilyGroup
        {
            get => _FamilyGroup;
            set => SetField(ref _FamilyGroup, value);
        }

        private ICollection<SubFamily> _SubFamilies;
        public virtual ICollection<SubFamily> SubFamilies
        {
            get => _SubFamilies;
            set => SetField(ref _SubFamilies, value);
        }
        #endregion

        #region Operators
        public override string ToString() => Code;

        public override bool Equals(object obj)
            => obj != null && obj.GetType().Equals(typeof(Family)) && this.FamilyId == ((Family)obj).FamilyId;

        public override int GetHashCode() => FamilyId;
        #endregion
    }
}
