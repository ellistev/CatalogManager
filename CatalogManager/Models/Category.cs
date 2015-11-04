using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class Category
    {
        public String Name;
        public List<Product> Products;
        public List<Category> SubCategories;

        public Category()
        {
            this.Products = new List<Product>();
            this.SubCategories = new List<Category>();
        }
    }
}