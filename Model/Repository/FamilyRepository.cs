using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class FamilyRepository : RepositoryBase<Family>
    {
        public FamilyRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public override IQueryable<Family> FindAll(bool trackChanges = false) => base.FindAll(trackChanges).OrderBy(r => r.Code);
    }
}
