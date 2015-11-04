﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatalogManager.Models;

namespace CatalogManager.Controllers
{
    public class CategoryController : Controller
    {

        public Dictionary<string, Category> allCategories;
        public Catalog catalog;

        public CategoryController()
        {
            this.catalog = CatalogSingleton.Instance;
            this.allCategories = CategoriesSingleton.Instance;
        }

        //
        // GET: /Category/
        public ActionResult Index(string name)
        {
            Category category = allCategories[name];
            return View(category);
        }

        //
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Catalog/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

        //
        // POST: /Catalog/Create
        [HttpPost]
        public ActionResult CreateProduct(FormCollection collection)
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

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(string name)
        {

            var category = allCategories[name];
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
                var originalCategory = allCategories[collection["originalCategoryName"]];
                originalCategory.Name = name;

                allCategories.Remove(collection["originalCategoryName"]);
                allCategories.Add(name, originalCategory);

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
        // GET: /Category/Delete/Name/PageType
        public ActionResult Delete(string name, string pageType)
        {

            if (pageType == "Main")
            {
                allCategories.Remove(name);
                catalog.MainCategories.Remove(name);
            }
            else if (pageType == "Category")
            {
                
                foreach (KeyValuePair<string, Category> entry in allCategories)
                {
                    if (entry.Value.SubCategories.Contains(name))
                    {
                        entry.Value.SubCategories.Remove(name);
                    }
                }
                allCategories.Remove(name);
                
            }

            return Redirect(System.Web.HttpContext.Current.Request.UrlReferrer.ToString());
            
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
