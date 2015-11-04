using System.Collections.Generic;

namespace CatalogManager.Models
{
    public class ProductsSingleton
    {
        private static Dictionary<string, Product> instance;

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