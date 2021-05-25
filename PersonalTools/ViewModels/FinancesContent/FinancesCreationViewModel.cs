using Core.BaseClasses;
using WpfLibrary.Commands;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalTools.ViewModels.FinancesContent
{
    public class FinancesCreationViewModel : BaseNotifyPropertyChanged
    {
        #region Properties
        private RepositoryManager _repositoryManager;

        private FinanceMovement _movement;
        public FinanceMovement Movement
        {
            get => _movement;
            set => SetField(ref _movement, value);
        }

        private IEnumerable<FamilyGroup> _familyGroups;
        public IEnumerable<FamilyGroup> FamilyGroups
        {
            get => _familyGroups;
            set => SetField(ref _familyGroups, value);
        }

        private IEnumerable<Family> _families;
        private IEnumerable<Family> _currentFamilies;
        public IEnumerable<Family> CurrentFamilies 
        { 
            get => _currentFamilies; 
            set => SetField(ref _currentFamilies, value); 
        }

        private IEnumerable<SubFamily> _subFamilies;
        private IEnumerable<SubFamily> _currentSubFamilies;
        public IEnumerable<SubFamily> CurrentSubFamilies
        {
            get => _currentSubFamilies;
            set => SetField(ref _currentSubFamilies, value);
        }

        private FamilyGroup _selectedFamilyGroup;
        public FamilyGroup SelectedFamilyGroup
        {
            get => _selectedFamilyGroup;
            set
            {
                if (SetField(ref _selectedFamilyGroup, value))
                {
                    CurrentFamilies = value == null ? null : _families.Where(r => r.FamilyGroupId == value.FamilyGroupId);
                    SelectedFamily = null;
                }
            }
        }

        private Family _selectedFamily;
        public Family SelectedFamily
        {
            get => _selectedFamily;
            set
            {
                if (SetField(ref _selectedFamily, value))
                {
                    CurrentSubFamilies = value == null ? null : _subFamilies.Where(r => r.FamilyId == value.FamilyId);
                    Movement.SubFamily = null;
                }
            }
        }

        private decimal? _quantity;
        public decimal? Quantity
        {
            get => _quantity;
            set
            {
                if (SetField(ref _quantity, value) && value != null)
                {
                    if (_amount != null)
                        SetField(ref _totalAmount, value * _amount, nameof(TotalAmount));
                    else if (_totalAmount != null)
                        SetField(ref _amount, value == 0 ? 0 : _totalAmount / value, nameof(Amount));
                }

                Movement.Quantity = value.GetValueOrDefault();
            }
        }

        private decimal? _amount;
        public decimal? Amount
        {
            get => _amount;
            set
            {
                if (SetField(ref _amount, value) && value != null)
                {
                    if (_quantity != null)
                        SetField(ref _totalAmount, value * _quantity, nameof(TotalAmount));
                    else if (_totalAmount != null)
                        SetField(ref _quantity, value == 0 ? 0 : _totalAmount / value, nameof(Quantity));
                }

                Movement.Amount = value.GetValueOrDefault();
            }
        }

        private decimal? _totalAmount;
        public decimal? TotalAmount
        {
            get => _totalAmount;
            set
            {
                if (value == null)
                    value = 0;

                if (SetField(ref _totalAmount, value))
                {
                    if (_quantity != null)
                        SetField(ref _amount, value == 0 ? 0 : value / _quantity, nameof(Amount));
                    else if (_amount != null)
                        SetField(ref _quantity, value == 0 ? 0 : value / _amount, nameof(Quantity));
                }
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(r => true, r => this.Save());
                return _saveCommand;
            }
        }
        #endregion

        #region Constructor
        public FinancesCreationViewModel(RepositoryManager repositoryManager, int? movementId = null)
        {
            _repositoryManager = repositoryManager;

            LoadFamilies();

            LoadMovement(movementId);
        }
        #endregion

        #region Methods
        private void LoadFamilies()
        {
            _familyGroups = _repositoryManager.FamilyGroups.FindAll().ToList();
            _families = _repositoryManager.Families.FindAll().ToList();
            _subFamilies = _repositoryManager.SubFamilies.FindAll().ToList();
        }

        private void LoadMovement(int? movementId)
        {
            if (movementId != null)
                Movement = _repositoryManager.FinanceMovements.FindByCondition(r => r.FinanceMovementId == movementId, true)
                    .Include(r => r.SubFamily).ThenInclude(r => r.Family).ThenInclude(r => r.FamilyGroup).FirstOrDefault();

            if (Movement == null)
            {
                Movement = FinanceMovement.FinanceMovementFactory();
                _repositoryManager.FinanceMovements.Insert(Movement);
            }
            else
            {
                SelectedFamilyGroup = Movement.SubFamily.Family.FamilyGroup;
                SelectedFamily = Movement.SubFamily.Family;

                _quantity = Movement.Quantity;
                _amount = Movement.Amount;
                _totalAmount = _quantity * _amount;
            }
        }

        private void Save()
        {
            _repositoryManager.SaveChanges();
        }
        #endregion
    }
}
