using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatalogManager.Models;
namespace CatalogManager.Controllers
{
    public class CatalogController : Controller
    {
        public Catalog catalog;

        public CatalogController()
        {
            this.catalog = CatalogSingleton.Instance;
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
            try
            {
                catalog.MainCategories.Add(collection["Name"]);
                catalog.Categories.Add(collection["Name"], new Category
                {
                    Name = collection["Name"]
                });

                return RedirectToAction("Index");
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

