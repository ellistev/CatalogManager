using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CatalogManager.Models;

namespace CatalogManager.Controllers
{
    public class ProductController : Controller
    {
        public Dictionary<string, Category> allCategories;
        public Dictionary<string, Product> allProducts;
        public Catalog catalog;

        public ProductController()
        {
            catalog = CatalogSingleton.Instance;
            allProducts = ProductsSingleton.Instance;
            allCategories = CategoriesSingleton.Instance;
        }

        //
        // GET: /Product/
        public ActionResult Index(string name)
        {
            var category = allProducts[name];
            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            return View(category);
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
            var newProductName = collection["Name"];
            try
            {
                //get products category parent
                if (allProducts.ContainsKey(newProductName))
                {
                    throw new ArgumentException();
                }
                var parentCategoryName = collection["ParentCategoryName"];
                var parentCategory = allCategories[parentCategoryName];
                catalog.Products.Add(newProductName, new Product
                {
                    Name = newProductName,
                    Price = Double.Parse(collection["Price"]),
                    Description = collection["Description"]
                });
                parentCategory.Products.Add(newProductName);

                return Redirect(collection["PreviousUrl"]);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError("", "Product Already Exists, Must Be Unique: " + newProductName);
                ViewBag.PreviousUrl = collection["PreviousUrl"];
                ViewBag.ParentCategoryName = collection["ParentCategoryName"];
                return View();
            }
            catch (Exception e)
            {
                ViewBag.PreviousUrl = collection["PreviousUrl"];
                ViewBag.ParentCategoryName = collection["ParentCategoryName"];
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
                if (collection["originalProductName"] != name && allProducts.ContainsKey(name))
                {
                    throw new ArgumentException();
                }
                var originalProduct = allProducts[collection["originalProductName"]];
                originalProduct.Name = name;
                originalProduct.Description = collection["Description"];
                originalProduct.Price = Double.Parse(collection["Price"]);

                allProducts.Remove(collection["originalProductName"]);
                allProducts.Add(name, originalProduct);

                foreach (var entry in allCategories)
                {
                    if (entry.Value.Products.Contains(collection["originalProductName"]))
                    {
                        entry.Value.Products.Remove(collection["originalProductName"]);
                        entry.Value.Products.Add(name);
                    }
                }

                return Redirect(collection["PreviousUrl"]);
            }catch (ArgumentException e)
            {
                ModelState.AddModelError("", "Product Already Exists, Must Be Unique: " + name);
                ViewBag.PreviousUrl = collection["PreviousUrl"];
                ViewBag.ParentCategoryName = collection["ParentCategoryName"];
                return View();
            }
            catch (Exception e)
            {
                ViewBag.PreviousUrl = collection["PreviousUrl"];
                ViewBag.ParentCategoryName = collection["ParentCategoryName"];
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
                foreach (var entry in allCategories)
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


    }
}