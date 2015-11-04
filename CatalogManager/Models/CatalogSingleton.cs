using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class CatalogSingleton
    {
        private static Catalog instance;

        public CatalogSingleton() { }

        public static Catalog Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Catalog();
                }
                return instance;
            }
        }
    }
}