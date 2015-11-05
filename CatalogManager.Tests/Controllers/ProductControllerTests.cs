using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CatalogManager.Controllers;
using CatalogManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CatalogManager.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void Sould_Add_New_Product()
        {
            string newCategoryToAdd = "newCategoryToAdd";

            ProductController controller = new ProductController();

            controller.allCategories.Add("parent", new Category
            {
                Name = "parent"
            });

            FormCollection collection = new FormCollection();
            collection.Add("ParentCategoryName", "parent");
            collection.Add("Name", "productname");
            collection.Add("Description", "description");
            collection.Add("Price", "1.23");

            controller.AddProduct(collection);

            Assert.AreEqual(controller.allProducts.Count, 1);
        }

        [TestMethod()]
        public void Sould_Not_Add_Duplicate_Product()
        {
            //add the first category
            string newCategoryToAdd = "parent";
            ProductController controller = new ProductController();

            controller.allCategories.Add("parent", new Category
            {
                Name = "parent"
            });

            FormCollection collection = new FormCollection();
            collection.Add("ParentCategoryName", "parent");
            collection.Add("productname", "newCategoryToAdd");


            controller.allProducts.Add("productname", new Product
            {
                Name = "productname",
                Description = "description",
                Price = 1.23

            });

            ArgumentException expectedException = null;

            try
            {
                collection = new FormCollection();
                collection.Add("ParentCategoryName", "parent");
                collection.Add("Name", "productname");
                collection.Add("Description", "description");
                collection.Add("Price", "1.23");

                controller.AddProduct(collection);
            }
            catch (ArgumentException ex)
            {
                expectedException = ex;
            }

            // Assert
            Assert.IsNotNull(expectedException);
            Assert.AreEqual(controller.allProducts.Count, 1);
        }

        [TestMethod()]
        public void Sould_Add_Edit_Product()
        {
            string newCategoryToAdd = "newCategoryToAdd";

            // Arrange
            CategoryController controller = new CategoryController();

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
