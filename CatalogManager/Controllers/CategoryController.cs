using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatalogManager.Models;

namespace CatalogManager.Controllers
{
    public class CategoryController : Controller
    {

        public Dictionary<string, Category> categories;
        public Catalog catalog;

        public CategoryController()
        {
            this.catalog = CatalogSingleton.Instance;
            this.categories = CategoriesSingleton.Instance;
        }

        //
        // GET: /Category/
        public ActionResult Index(string name)
        {
            Category category = categories[name];
            return View(category);
        }

        //
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(string name)
        {

            var category = categories[name];
            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            return View(category);
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(string name, FormCollection collection)
        {
            try
            {
                var originalCategory = categories[collection["originalCategoryName"]];
                originalCategory.Name = name;
                categories.Remove(collection["originalCategoryName"]);
                categories.Add(name, originalCategory);
                catalog.MainCategories.Remove(collection["originalCategoryName"]);
                catalog.MainCategories.Add(name);

                return Redirect(collection["PreviousUrl"]);
                
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5
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
