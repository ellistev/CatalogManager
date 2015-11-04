using System.Collections.Generic;

namespace CatalogManager.Models
{
    public class Catalog
    {
        public Dictionary<string, Category> Categories;
        //public List<Category> Categories;
        public List<string> MainCategories;
        public Dictionary<string, Product> Products;

        public Catalog()
        {
            MainCategories = new List<string>();
            Categories = CategoriesSingleton.Instance;
            Products = ProductsSingleton.Instance;
        }
    }
}