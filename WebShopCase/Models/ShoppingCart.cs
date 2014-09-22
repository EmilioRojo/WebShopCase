using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopCase.Models;
using WebShopCase.DI;

namespace WebShopCase.Models
{
    public class ShoppingCart
    {
                
        private List<ItemCart> Cart { get; set; }

        public ShoppingCart(Object sessionvalue)
        {
            if (sessionvalue==null)
            {
                Cart = new List<ItemCart>();
            }else{
                Cart = ((ShoppingCart)sessionvalue).Cart;
            }
        }

        public List<ItemCart> GetCart()
        {
            return Cart;    
        }


        public int NumberItems()
        {
            return Cart.Sum(p => p.Quantity);
        }

        public ShoppingCart Add(int prodid)
        {
            int qty = 1;
            ItemCart existingItem = Cart.Find(p => p.ProductId == prodid);

            if (existingItem != null)
            {
                qty = existingItem.Quantity + 1;
                Cart.Remove(existingItem);
            }
            
            //DEPENDENCY INJECTION!!

            //IProductRepository prodrepo = new XMLProductRepository();
            IProductRepository prodrepo = (IProductRepository)DIResolver.GetClass<IProductRepository>();


            Product selectedprod = prodrepo.GetProduct(prodid);
            string prodname = selectedprod.Name;
            decimal prodprice = selectedprod.Price;

            Cart.Add(new ItemCart() { ProductId = prodid, 
                                      Product = prodname, 
                                      Quantity = qty, 
                                      UnitPrice = prodprice,
                                      Price = decimal.Round(qty * prodprice,2)
            });

            return this;
        }


        public decimal ExVatPrice()
        {
            return decimal.Round(Cart.Sum(x => x.Price),2);
        }

        public decimal VAT()
        {
            //DEPENDENCY INJECTION!!
            //IParameterRepository paramrepo = new XMLParameterRepository();
            IParameterRepository paramrepo = (IParameterRepository)DIResolver.GetClass<IParameterRepository>();            
            return decimal.Parse(paramrepo.getParameter("VAT"));
        }

        public decimal VATPrice()
        {
            return decimal.Round(Cart.Sum(x => x.Price * VAT()/100),2);
        }

        public decimal TotalPrice()
        {
            return ExVatPrice() + VATPrice();
        }

    }

    public class ItemCart
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
    }

}