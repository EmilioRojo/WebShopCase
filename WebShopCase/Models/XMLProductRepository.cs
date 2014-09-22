using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShopCase.Models
{
    public class XMLProductRepository : IProductRepository
    {
        string FilePath = HttpContext.Current.Server.MapPath("~/App_Data/Products.xml");
       
        public IEnumerable<Product> GetAllProducts()
        {

            XDocument productsXML = XDocument.Load(FilePath);
            List<Product> result = (from prod in productsXML.Descendants("Product")
                                    orderby Convert.ToInt32(prod.Attribute("ID").Value)
                                    select new Product
                                    {
                                        Id = Convert.ToInt32(prod.Attribute("ID").Value),
                                        Name = prod.Element("Name").Value,
                                        Description = prod.Element("Description").Value,
                                        Price = Convert.ToDecimal(prod.Element("Price").Value)
                                    }).ToList<Product>();            
            return result;
        }

        public Product GetProduct(int id)
        {
            XDocument productsXML = XDocument.Load(FilePath);
            Product result = (from prod in productsXML.Descendants("Product")
                              where prod.Attribute("ID").Value == id.ToString()
                              select new Product
                              {
                                  Id = Convert.ToInt32(prod.Attribute("ID").Value),
                                  Name = prod.Element("Name").Value,
                                  Description = prod.Element("Description").Value,
                                  Price = Convert.ToDecimal(prod.Element("Price").Value)
                              }).SingleOrDefault<Product>();

            return result;
        }        
    }
}