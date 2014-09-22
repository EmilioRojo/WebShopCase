using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShopCase.Models
{
    public class XMLCustomerRepository : ICustomerRepository
    {
        string FilePath = HttpContext.Current.Server.MapPath("~/App_Data/Customers.xml");

        public int SaveClient(Customer customer)
        {
           
            XDocument customersXML = XDocument.Load(FilePath);
            int nextCustomer = (from prod in customersXML.Descendants("Customer")
                             select prod).Count() + 1;

            XElement newCustomer= new XElement("Customer",new XAttribute("ID",nextCustomer),
            new XElement("Title", customer.Title.ToUpper()),
            new XElement("FirstName", customer.FirstName.ToUpper()),
            new XElement("LastName", customer.LastName.ToUpper()),
            new XElement("Address", customer.Address.ToUpper()),
            new XElement("HouseNumber", customer.HouseNumber.ToUpper()),
            new XElement("ZipCode", customer.ZipCode.ToUpper()),
            new XElement("City", customer.City.ToUpper()),
            new XElement("Email", customer.Email.ToUpper())            
            );

            customersXML.Descendants("Customers").First().Add(newCustomer);
            customersXML.Save(FilePath);


            return nextCustomer;
        }
    }
}