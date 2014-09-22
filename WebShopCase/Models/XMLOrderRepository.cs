using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShopCase.Models
{
    public class XMLOrderRepository : IOrderRepository
    {
        string FilePath = HttpContext.Current.Server.MapPath("~/App_Data/Orders.xml");

        public int SaveOrder(int clientid, ShoppingCart cart)
        {
            decimal VAT = cart.VAT();
            decimal exVATPrice = cart.ExVatPrice();
            decimal VATPRice = cart.VATPrice();
            decimal TotalPrice = cart.TotalPrice();

            XDocument ordersXML = XDocument.Load(FilePath);
            int nextOrder = (from order in ordersXML.Descendants("Order")
                             select order).Count() + 1;


            XElement XMLProducts =  new XElement("Products");
            foreach(ItemCart item in cart.GetCart())
            {
                XMLProducts.Add(new XElement("Product",new XAttribute("ID", item.ProductId),
                    new XElement("Quantity",item.Quantity),
                    new XElement("UnitPrice",item.UnitPrice),
                    new XElement("Price",item.Price))
                    );
            } 
            

            XElement newOrder = new XElement("Order", new XAttribute("ID", nextOrder),
                new XElement("CustomerID", clientid),
                new XElement("ExVatPrice", cart.ExVatPrice()),
                new XElement("VAT", cart.VAT()),
                new XElement("VATPrice", cart.VATPrice()),
                new XElement("TotalPrice", cart.TotalPrice()),
                XMLProducts
            );

            ordersXML.Descendants("Orders").First().Add(newOrder);
            ordersXML.Save(FilePath);

            return nextOrder;
        }
    }
}