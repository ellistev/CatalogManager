using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class Product
    {
        public string Name{
            set;
            get;
        }
        public string Description{
            set;
            get;
        }

        public decimal Price
        {
            set;
            get;
        }

        public Product()
        {
            
        }

    }


}