using System.Collections.Generic;

namespace CatalogManager.Models
{
    public class CategoriesSingleton
    {
        private static Dictionary<string, Category> instance;

        public static Dictionary<string, Category> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dictionary<string, Category>();
                }
                return instance;
            }
        }
    }
}