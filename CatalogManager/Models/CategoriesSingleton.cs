using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogManager.Models
{
    public class CategoriesSingleton
    {
        private static Dictionary<string, Category> instance;

        public CategoriesSingleton() { }

        public static Dictionary<string, Category> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new  Dictionary<string, Category>();
                }
                return instance;
            }
        }
    }
}