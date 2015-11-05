using System;
using System.Collections.Generic;
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
            catalog = CatalogSingleton.Instance;
            allCategories = CategoriesSingleton.Instance;
        }

        //
        // GET: /Category/
        public ActionResult Index(string name)
        {
            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            var category = allCategories[name];
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
            var newCategoryName = collection["Name"];
            try
            {
                //get products category parent
                if (allCategories.ContainsKey(newCategoryName))
                {
                    throw new ArgumentException();
                }
                var parentCategoryName = collection["ParentCategoryName"];
                var parentCategory = allCategories[parentCategoryName];
                allCategories.Add(collection["Name"], new Category
                {
                    Name = collection["Name"]
                });
                parentCategory.SubCategories.Add(collection["Name"]);

                return Redirect(collection["PreviousUrl"]);
            }catch (ArgumentException e)
            {
                ModelState.AddModelError("", "Category Already Exists, Must Be Unique: " + newCategoryName);
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
        public ActionResult Edit(string name, string pageType, FormCollection collection)
        {
            try
            {

                if (collection["originalCategoryName"] != name && allCategories.ContainsKey(name))
                {
                    throw new ArgumentException();
                }
                var originalCategory = allCategories[collection["originalCategoryName"]];
                originalCategory.Name = name;

                allCategories.Remove(collection["originalCategoryName"]);
                allCategories.Add(name, originalCategory);


                if (pageType == null || pageType == "Main")
                {
                    catalog.MainCategories.Remove(collection["originalCategoryName"]);
                    catalog.MainCategories.Add(name);
                }
                else if (pageType == "Category")
                {
                    foreach (var entry in allCategories)
                    {
                        if (entry.Value.SubCategories.Contains(collection["originalCategoryName"]))
                        {
                            entry.Value.SubCategories.Remove(collection["originalCategoryName"]);
                            entry.Value.SubCategories.Add(name);
                        }
                    }
                }


                return Redirect(collection["PreviousUrl"]);
            }catch (ArgumentException e)
            {
                ModelState.AddModelError("", "Category Already Exists, Must Be Unique: " + name);
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
                allCategories.Remove(name);
                catalog.MainCategories.Remove(name);
            }
            else if (pageType == "Category")
            {
                foreach (var entry in allCategories)
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


    }
}