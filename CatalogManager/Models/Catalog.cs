using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class Catalog
    {
        public List<Category> Categories;

        public Catalog()
        {
            this.Categories = new List<Category>();
        }
    }
}