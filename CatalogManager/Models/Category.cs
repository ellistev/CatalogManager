using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogManager.Models
{
    public class Category
    {
        public Dictionary<string, Category> AllCategories;
        public Dictionary<string, Product> AllProducts;

        [Required]
        public String Name { get; set; }

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