using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogManager.Models
{
    public class Category : Catalog
    {

        [Required]
        public String Name { get; set; }

        public List<string> Products;
        public List<string> SubCategories;

        public Category()
        {
            Products = new List<string>();
            SubCategories = new List<string>();
        }
    }
}