﻿using System;
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
        public ActionResult Edit(string name, string parentCategoryName)
        {
            var product = allProducts[name];
            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            ViewBag.ParentCategoryName = parentCategoryName;
            return View(product);
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(string name, FormCollection collection)
        {
            try
            {
                var originalProduct = allProducts[collection["originalProductName"]];
                originalProduct.Name = name;
                originalProduct.Description = collection["Description"];
                originalProduct.Price = collection["Price"];

                allProducts.Remove(collection["originalProductName"]);
                allProducts.Add(name, originalProduct);

                foreach (KeyValuePair<string, Category> entry in allCategories)
                {
                    if (entry.Value.Products.Contains(collection["originalProductName"]))
                    {
                        entry.Value.Products.Remove(collection["originalProductName"]);
                        entry.Value.Products.Add(name);
                    }
                }

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
                allProducts.Remove(name);
            }
            else if (pageType == "Category")
            {

                foreach (KeyValuePair<string, Category> entry in allCategories)
                {
                    if (entry.Value.Products.Contains(name))
                    {
                        entry.Value.Products.Remove(name);
                    }
                }
                allProducts.Remove(name);

            }

            return Redirect(System.Web.HttpContext.Current.Request.UrlReferrer.ToString());

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
