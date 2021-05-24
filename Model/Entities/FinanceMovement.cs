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
    [Table("FinanceMovements")]
    public class FinanceMovement : BaseNotifyPropertyChanged
    {
        #region Properties
        private int _FinanceMovementId;
        public int FinanceMovementId
        {
            get => _FinanceMovementId;
            set => SetField(ref _FinanceMovementId, value);
        }

        private DateTime _Date;
        public DateTime Date
        {
            get => _Date;
            set => SetField(ref _Date, value);
        }

        private string _Concept;
        [Required]
        public string Concept
        {
            get => _Concept;
            set => SetField(ref _Concept, value);
        }

        private string _Comment;
        public string Comment
        {
            get => _Comment;
            set => SetField(ref _Comment, value);
        }

        private decimal _Quantity;
        public decimal Quantity
        {
            get => _Quantity;
            set => SetField(ref _Quantity, value);
        }

        private decimal _Amount;
        public decimal Amount
        {
            get => _Amount;
            set => SetField(ref _Amount, value);
        }

        private bool _IsBreakdown;
        public bool IsBreakdown
        {
            get => _IsBreakdown;
            set => SetField(ref _IsBreakdown, value);
        }

        private int _SubFamilyId;
        public int SubFamilyId
        {
            get => _SubFamilyId;
            set => SetField(ref _SubFamilyId, value);
        }

        private SubFamily _SubFamily;
        public virtual SubFamily SubFamily
        {
            get => _SubFamily;
            set => SetField(ref _SubFamily, value);
        }

        private int? _BreakDownId;
        public int? BreakDownId
        {
            get => _BreakDownId;
            set => SetField(ref _BreakDownId, value);
        }

        private FinanceMovement _BreakDown;
        public virtual FinanceMovement BreakDown
        {
            get => _BreakDown;
            set => SetField(ref _BreakDown, value);
        }

        private ICollection<FinanceMovement> _BreakDownDetails;
        public virtual ICollection<FinanceMovement> BreakDownDetails
        {
            get => _BreakDownDetails;
            set => SetField(ref _BreakDownDetails, value);
        }
        #endregion
    }
}
