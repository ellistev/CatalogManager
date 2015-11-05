using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebSockets;
using CatalogManager.Controllers;
using CatalogManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CatalogManager.Controllers.Tests
{
    [TestClass()]
    public class CategoryControllerTests
    {
        [TestMethod()]
        public void Sould_Add_New_Category()
        {
            string newCategoryToAdd = "newCategoryToAdd";
            
            CategoryController controller = new CategoryController();
            controller.allCategories.Clear();

            controller.allCategories.Add("parent", new Category
            {
                Name = "parent"
            });

            FormCollection collection = new FormCollection();
            collection.Add("ParentCategoryName", "parent");
            collection.Add("Name", "newCategoryToAdd");

            controller.AddCategory(newCategoryToAdd, collection);
            
            Assert.AreEqual(controller.allCategories.Count, 2);
        }

        [TestMethod()]
        public void Sould_Not_Add_Duplicate_Category()
        {
            //add the first category
            string newCategoryToAdd = "parent";
            CategoryController controller = new CategoryController();
            controller.allCategories.Clear();

            controller.allCategories.Add("parent", new Category
            {
                Name = "parent"
            });

            FormCollection collection = new FormCollection();
            collection.Add("ParentCategoryName", "parent");
            collection.Add("Name", "newCategoryToAdd");
            

            ArgumentException expectedException = null;

            try
            {
                //attempt to add again the same category
                controller.AddCategory(newCategoryToAdd, collection);
            }
            catch (ArgumentException ex)
            {
                expectedException = ex;
            }

            // Assert
            Assert.IsNotNull(expectedException);
            Assert.AreEqual(controller.allCategories.Count, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "A Duplicate Entry is Not Allowed.")]
        public void Sould_Add_Edit_Category()
        {
            string newCategoryToAdd = "newCategoryToAdd";

            // Arrange
            CategoryController controller = new CategoryController();
            controller.allCategories.Clear();

            controller.EditCategory(newCategoryToAdd);

            // Assert
            Assert.AreEqual(controller.catalog.MainCategories.Count, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "A Duplicate Entry is Not Allowed.")]
        public void Sould_Not_Edit_Duplicate_Category()
        {
            //add the first category
            string newCategoryToAdd = "newCategoryToAdd";
            CategoryController controller = new CategoryController();
            controller.allCategories.Clear();

            controller.EditCategory(newCategoryToAdd);

            ArgumentException expectedException = null;

            try
            {
                //attempt to add again the same category
                controller.EditCategory(newCategoryToAdd);
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
