using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace UnitTesting
{
    [TestClass]
    public class ModelTesting
    {
        //[TestMethod]
        //public void CreationWWorks()
        //{
        //    RepositoryContext dataContext = new RepositoryContext();

        //    FamilyGroup group = new FamilyGroup
        //    {
        //        Code = "GRP"
        //    };
        //    dataContext.FamilyGroups.Add(group);
        //    dataContext.SaveChanges();

        //    Family family = new Family
        //    {
        //        Code = "FAM",
        //        FamilyGroup = group
        //    };
        //    dataContext.Families.Add(family);
        //    dataContext.SaveChanges();

        //    SubFamily subFamily = new SubFamily
        //    {
        //        Code = "SUB",
        //        Family = family
        //    };
        //    dataContext.SubFamilies.Add(subFamily);
        //    dataContext.SaveChanges();
        //}

        //[TestMethod]
        //public void CreationBreakdown()
        //{
        //    RepositoryContext dataContext = new RepositoryContext();

        //    SubFamily subFamily = dataContext.SubFamilies.First();

        //    FinanceMovement mov1 = new FinanceMovement
        //    {
        //        Amount = 0,
        //        Concept = "Cabecera desglose",
        //        Date = DateTime.Today,
        //        IsBreakdown = true,
        //        Quantity = 0,
        //        SubFamily = subFamily
        //    };
        //    dataContext.FinanceMovements.Add(mov1);
        //    dataContext.FinanceMovements.Add(new FinanceMovement
        //    {
        //        Amount = 100,
        //        BreakDown = mov1,
        //        Concept = "Desglose 1",
        //        Date = DateTime.Today,
        //        IsBreakdown = false,
        //        Quantity = 1,
        //        SubFamily = subFamily
        //    });
        //    dataContext.FinanceMovements.Add(new FinanceMovement
        //    {
        //        Amount = 50,
        //        BreakDown = mov1,
        //        Concept = "Desglose 2",
        //        Date = DateTime.Today,
        //        IsBreakdown = false,
        //        Quantity = 3,
        //        SubFamily = subFamily
        //    });
        //    dataContext.FinanceMovements.Add(new FinanceMovement
        //    {
        //        Amount = 69,
        //        BreakDown = mov1,
        //        Concept = "Desglose 3",
        //        Date = DateTime.Today,
        //        IsBreakdown = false,
        //        Quantity = 420,
        //        SubFamily = subFamily
        //    });
        //    dataContext.SaveChanges();
        //}

        //[TestMethod]
        //public void Include()
        //{
        //    RepositoryContext dataContext = new RepositoryContext();

        //    FinanceMovement mov = dataContext.FinanceMovements.Include(r => r.BreakDownDetails).First(r => r.IsBreakdown);
        //    FinanceMovement mov2 = dataContext.FinanceMovements.Include(r => r.BreakDown).First(r => !r.IsBreakdown);

        //    Assert.IsNotNull(mov.BreakDownDetails);
        //    Assert.IsNotNull(mov2.BreakDown);
        //}
    }
}
