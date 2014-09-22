using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopCase.Models;
using WebShopCase.DI;

namespace WebShopCase.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: /CheckOut/
        public ViewResult Index()
        {

            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public ViewResult Index(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //DEPENDENCY INJECTION!!
                //ICustomerRepository customerrepo = new XMLCustomerRepository();
                //IOrderRepository orderrepo = new XMLOrderRepository();
                ICustomerRepository customerrepo = (ICustomerRepository) DIResolver.GetClass<ICustomerRepository>();
                IOrderRepository orderrepo = (IOrderRepository) DIResolver.GetClass<IOrderRepository>();


                //Save Client
                int customerid = customerrepo.SaveClient(customer);

                //Save Order
                ShoppingCart sscart = new ShoppingCart(Session["cart"]);
                int orderid = orderrepo.SaveOrder(customerid, sscart);


                ViewBag.OrderNo = orderid;
                ViewBag.Name = customer.Title + " " + customer.FirstName + " " + customer.LastName;

                return View("ThankYou");
            }else{
                return View();
            }
            
        }
	}
}