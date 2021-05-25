﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class FinanceMovementRepository : RepositoryBase<FinanceMovement>
    {
        public FinanceMovementRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    }
}
