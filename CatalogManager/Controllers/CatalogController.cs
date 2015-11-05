using System;
using System.Text;
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

                AddMainCategory(newCategoryName);

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

        public ActionResult FullCatalog()
        {
            return View(catalog);
        }

        public void AddMainCategory(string newCategoryName)
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
        }

        



    }
}