using System;
using System.Collections.Generic;

namespace CatalogManager.Models
{
    public class Category
    {
        public Dictionary<string, Category> AllCategories;
        public Dictionary<string, Product> AllProducts;
        public String Name;
        public List<string> Products;
        public List<string> SubCategories;

        public Category()
        {
            Products = new List<string>();
            SubCategories = new List<string>();
            AllCategories = CategoriesSingleton.Instance;
            AllProducts = ProductsSingleton.Instance;
        }
    }
}