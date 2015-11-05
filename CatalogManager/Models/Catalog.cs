using System.Collections.Generic;

namespace CatalogManager.Models
{
    public class Catalog
    {
        public Dictionary<string, Category> AllCategories;
        //public List<Category> Categories;
        public List<string> MainCategories;
        public Dictionary<string, Product> AllProducts;

        public Catalog()
        {
            MainCategories = new List<string>();
            AllCategories = CategoriesSingleton.Instance;
            AllProducts = ProductsSingleton.Instance;
        }
    }
}