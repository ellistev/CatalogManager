using System;
using System.Web.Mvc;
using CatalogManager.Models;

namespace CatalogManager.Controllers
{
    public class CatalogController : Controller
    {
        public Catalog catalog;

        public CatalogController()
        {
            catalog = CatalogSingleton.Instance;
        }

        //
        // GET: /Catalog/
        public ActionResult Index()
        {
            return View(catalog);
        }

        //
        // GET: /Catalog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Catalog/Create
        public ActionResult CreateCategory()
        {
            return View();
        }

        //
        // POST: /Catalog/Create
        [HttpPost]
        public ActionResult CreateCategory(FormCollection collection)
        {
            var newCategoryName = collection["Name"];

            try
            {
                if (catalog.MainCategories.Contains(newCategoryName))
                {
                    throw new ArgumentException();
                }
                catalog.MainCategories.Add(newCategoryName);
                catalog.Categories.Add(newCategoryName, new Category
                {
                    Name = newCategoryName
                });

                return RedirectToAction("Index");
            }catch (ArgumentException e){
                ModelState.AddModelError("", "Category Already Exists, Must Be Unique: " + newCategoryName);
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Catalog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Catalog/Edit/5
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
        // GET: /Catalog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Catalog/Delete/5
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