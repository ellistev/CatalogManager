using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatalogManager.Models;

namespace CatalogManager.Helpers
{
    public class CatalogHelpers
    {

        public static string ShowSubItems(Category _object)
        {
             StringBuilder output = new StringBuilder();
             if(_object.Products.Count > 0)
             {
                 output.Append("<ul>");

                 foreach(string subItem in _object.Products)
                 {
                     var product = _object.AllProducts[subItem];
                     output.Append("<li>");
                     output.Append(product.Name);
                     output.Append("</li>");
                 }
                 output.Append("</ul>");

                 output.Append("<ul>");

                 foreach(string subItem in _object.SubCategories)
                 {
                     var category = _object.AllCategories[subItem];
                     output.Append("<li>");
                     output.Append(category.Name);
                     output.Append(ShowSubItems(category));
                     output.Append("</li>");
                 }
                 output.Append("</ul>");
             }
             return output.ToString();
        }

    }
}