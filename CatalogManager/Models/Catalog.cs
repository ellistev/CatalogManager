using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class Catalog
    {
        //public List<Category> Categories;
        public List<string> MainCategories;
        public Dictionary<string, Category> Categories;
        public Dictionary<string, Product> Products;

        public Catalog()
        {
            this.MainCategories = new List<string>();
            this.Categories = CategoriesSingleton.Instance;
            this.Products = ProductsSingleton.Instance;
        }
    }
}
