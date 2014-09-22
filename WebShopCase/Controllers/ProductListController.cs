using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShopCase.Models;
using WebShopCase.DI;
namespace WebShopCase.Controllers
{
    public class ProductListController : ApiController
    {
        //DEPENDENCY INJECTION!!
        //private IProductRepository repo = new XMLProductRepository();
        private IProductRepository repo = (IProductRepository) DIResolver.GetClass<IProductRepository>();


        private const int productsPerPage = 10;
        [Route("api/productlist")]
        public IEnumerable<Product> GetProductList()
        {
            return repo.GetAllProducts();
        }

        [Route("api/productlist/{page:int}")]
        public CurrentPage GetProductList(int page)
        {
            CurrentPage retpage = new CurrentPage();
            IEnumerable<Product> allproducts = repo.GetAllProducts();
            retpage.productlist = allproducts.Skip(productsPerPage * (page-1)).Take(productsPerPage);
            retpage.currentPage = page;
            retpage.lastPage = (int)Math.Ceiling((decimal)allproducts.Count() / (decimal)productsPerPage);
            return retpage;
        }


        public class CurrentPage
        {
            public IEnumerable<Product> productlist { get; set; }
            public int currentPage { get; set; }            
            public int lastPage { get; set; }
        }
    }

}
