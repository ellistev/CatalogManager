using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatalogManager.Models;

namespace CatalogManager.Controllers
{
    public class ProductController : Controller
    {

        public Dictionary<string, Product> allProducts;
        public Dictionary<string, Category> allCategories;
        public Catalog catalog;

        public ProductController()
        {
            this.catalog = CatalogSingleton.Instance;
            this.allProducts = ProductsSingleton.Instance;
            this.allCategories = CategoriesSingleton.Instance;
        }


        //
        // GET: /Product/
        public ActionResult Index(string name)
        {
            Product category = allProducts[name];
            return View(category);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create
        public ActionResult Create(string parentCategoryName)
        {
            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            ViewBag.ParentCategoryName = parentCategoryName;
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //get products category parent
                var parentCategoryName = collection["ParentCategoryName"];
                var parentCategory = allCategories[parentCategoryName];
                catalog.Products.Add(collection["Name"], new Product
                {
                    Name = collection["Name"],
                    Price = collection["Price"],
                    Description = collection["Description"]

                });
                parentCategory.Products.Add(collection["Name"]);

                return Redirect(collection["PreviousUrl"]);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
