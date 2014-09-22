using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopCase.Models;

namespace WebShopCase.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart sscart;

        // GET: /Home/
        public ViewResult Index()
        {
            sscart = new ShoppingCart(Session["cart"]);
           
            ViewBag.ExVatPrice = sscart.ExVatPrice();
            ViewBag.VAT = sscart.VAT();
            ViewBag.VATPrice = sscart.VATPrice();
            ViewBag.TotalPrice = sscart.TotalPrice();

            return View(sscart);
        }

        [HttpPost]
        public int cartCount()
        {
            sscart = new ShoppingCart(Session["cart"]);
            return sscart.NumberItems();        
        }

        [HttpPost]
        public int addToCart(int prodid)
        {
            sscart = new ShoppingCart(Session["cart"]);
           
            Session["cart"] = sscart.Add(prodid);

            return sscart.NumberItems();
        }
    }
}
