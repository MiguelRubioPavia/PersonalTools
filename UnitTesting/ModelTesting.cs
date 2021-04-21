using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.IO;
using System.Linq;

namespace UnitTesting
{
    [TestClass]
    public class ModelTesting
    {
        [TestMethod]
        public void DatabaseConnectionWorks()
        {
            DataContext dataContext = new DataContext();

            var f = dataContext.FamilyGroups.FirstOrDefault();

            Assert.IsNotNull(dataContext);
        }

        [TestMethod]
        public void RelationsWork()
        {
            DataContext dataContext = new DataContext();
            var familyGroup = dataContext.FamilyGroups.Include(r => r.Families).First();
            //var families = dataContext.Families.ToList();

            Assert.IsNotNull(familyGroup);
            //Assert.IsTrue(families.Any());
            Assert.IsTrue(familyGroup.Families.ToList().Any());
        }
    }
}
