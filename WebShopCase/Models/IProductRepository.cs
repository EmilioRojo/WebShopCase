using System.Collections.Generic;
namespace WebShopCase.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
    }
}