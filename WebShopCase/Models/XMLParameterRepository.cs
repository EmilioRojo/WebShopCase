using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebShopCase.Models
{
    public class XMLParameterRepository : IParameterRepository
    {
        string FilePath = HttpContext.Current.Server.MapPath("~/App_Data/Parameters.xml");

        public string getParameter(string param)
        {
            XDocument productsXML = XDocument.Load(FilePath);
            string value = (from prm in productsXML.Descendants("Parameter")
                              where prm.Attribute("ID").Value == param
                              select prm.Value).SingleOrDefault<string>();

            return value;
        }
    }
}