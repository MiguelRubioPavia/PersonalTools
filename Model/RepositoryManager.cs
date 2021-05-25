using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RepositoryManager : IDisposable
    {
        private RepositoryContext _repositoryContext;

        private FamilyGroupRepository _familyGroupRepository;
        public FamilyGroupRepository FamilyGroups
        {
            get
            {
                if (_familyGroupRepository == null)
                    _familyGroupRepository = new FamilyGroupRepository(_repositoryContext);
                return _familyGroupRepository;
            }
        }

        private FamilyRepository _familyRepository;
        public FamilyRepository Families
        {
            get
            {
                if (_familyRepository == null)
                    _familyRepository = new FamilyRepository(_repositoryContext);
                return _familyRepository;
            }
        }

        private SubFamilyRepository _subFamilyRepository;
        public SubFamilyRepository SubFamilies
        {
            get
            {
                if (_subFamilyRepository == null)
                    _subFamilyRepository = new SubFamilyRepository(_repositoryContext);
                return _subFamilyRepository;
            }
        }

        private FinanceMovementRepository _financeMovementRepository;
        public FinanceMovementRepository FinanceMovements
        {
            get
            {
                if (_financeMovementRepository == null)
                    _financeMovementRepository = new FinanceMovementRepository(_repositoryContext);
                return _financeMovementRepository;
            }
        }

        public RepositoryManager()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void SaveChanges() => _repositoryContext.SaveChanges();

        public void Dispose() => _repositoryContext.Dispose();
    }
}
