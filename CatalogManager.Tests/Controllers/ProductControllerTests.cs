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
        private ProductController controller;
        
        [TestMethod()]
        public void Sould_Add_New_Product()
        {
            string newCategoryToAdd = "newCategoryToAdd";

            controller = new ProductController();
            controller.allProducts.Clear();
            controller.allCategories.Clear();

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
            controller = new ProductController();
            controller.allProducts.Clear();
            controller.allCategories.Clear();

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
        public void Sould_Edit_Product()
        {
            string newProductName = "newName";

            // Arrange
            controller = new ProductController();
            controller.allProducts.Clear();
            controller.allCategories.Clear();

            FormCollection collection = new FormCollection();

            controller.allProducts.Add("originalName", new Product
            {
                Name = "originalName",
                Description = "description",
                Price = 1.23

            });

            collection.Add("ParentCategoryName", "parent");
            collection.Add("Name", "productname");
            collection.Add("Description", "description");
            collection.Add("Price", "1.23");
            collection.Add("originalProductName", "originalName");
            

            controller.EditProduct(newProductName, collection);

            // Assert
            Assert.AreEqual(controller.allProducts.Count, 1);
        }

        [TestMethod()]
        public void Sould_Not_Edit_Duplicate_Category()
        {
            string newProductToAdd = "otherName";
            controller = new ProductController();
            controller.allProducts.Clear();
            controller.allCategories.Clear();

            FormCollection collection = new FormCollection();

            controller.allProducts.Add("otherName", new Product
            {
                Name = "otherName",
                Description = "description",
                Price = 1.23

            });

            controller.allProducts.Add("originalName", new Product
            {
                Name = "originalName",
                Description = "description",
                Price = 1.23
            });

            collection.Add("ParentCategoryName", "parent");
            collection.Add("Name", "productname");
            collection.Add("Description", "description");
            collection.Add("Price", "1.23");
            collection.Add("originalProductName", "originalName");

            ArgumentException expectedException = null;

            try
            {
                controller.EditProduct(newProductToAdd, collection);
            }
            catch (ArgumentException ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
            Assert.AreEqual(controller.allProducts.Count, 2);
        }
    }
}
