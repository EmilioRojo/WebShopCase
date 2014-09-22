using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCase.Models
{
    public interface IOrderRepository
    {
        int SaveOrder(int clientid, ShoppingCart cart);
    }
}
