namespace CatalogManager.Models
{
    public class CatalogSingleton
    {
        private static Catalog instance;

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