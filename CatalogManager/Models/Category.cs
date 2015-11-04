using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class Category
    {
        public String Name;
        public List<string> Products;
        public List<string> SubCategories;

        public Category()
        {
            this.Products = new List<string>();
            this.SubCategories = new List<string>();
        }
    }
}