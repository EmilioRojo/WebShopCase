using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopCase.Models;



namespace WebShopCase.DI
{
    public static class DIResolver
    {
        public static Object GetClass<T>(){

            if (typeof(T)==typeof(ICustomerRepository))
            {
                return new XMLCustomerRepository();
            }
            else if (typeof(T) == typeof(IOrderRepository))
            {
                return new XMLOrderRepository();
            }
            else if (typeof(T) == typeof(IParameterRepository))
            {
                return new XMLParameterRepository();
            }
            else if (typeof(T) == typeof(IProductRepository)) 
            { 
                return new XMLProductRepository();
            }
            else
            {
                return null;
            }
        }
    }
}