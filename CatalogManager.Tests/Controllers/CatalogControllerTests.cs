using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogManager.Controllers;
using CatalogManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CatalogManager.Controllers.Tests
{
    [TestClass()]
    public class CatalogControllerTests
    {
    
        [TestMethod()]
        public void Sould_Add_New_MainCategory()
        {
            string newCategoryToAdd = "newCategoryToAdd";

            // Arrange
            CatalogController controller = new CatalogController();

            controller.AddMainCategory(newCategoryToAdd);
            
            // Assert
            Assert.AreEqual(controller.catalog.MainCategories.Count, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "A Duplicate Entry is Not Allowed.")]
        public void Sould_Not_Add_Duplicate_MainCategory()
        {
            //add the first category
            string newCategoryToAdd = "newCategoryToAdd";
            CatalogController controller = new CatalogController();
            controller.AddMainCategory(newCategoryToAdd);

            ArgumentException expectedException = null;

            try
            {
                //attempt to add again the same category
                controller.AddMainCategory(newCategoryToAdd);
            }
            catch (ArgumentException ex)
            {
                expectedException = ex;
            }

            // Assert
            Assert.IsNotNull(expectedException);
            Assert.AreEqual(controller.catalog.MainCategories.Count, 1);
        }
    }
}
