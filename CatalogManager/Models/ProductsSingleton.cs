using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class ProductsSingleton
    {
        private static Dictionary<string, Product> instance;

        public ProductsSingleton() { }

        public static Dictionary<string, Product> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dictionary<string, Product>();
                }
                return instance;
            }
        }
    }
}