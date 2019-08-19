using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Services
{
    public class BasketService
    {
        IRespository<Product> productContext;
        IRespository<Basket> basketContext;

        public const string BasketSession = "eCommerceBasket";

        public BasketService(IRespository<Product> productContext, IRespository<Basket> basketContext)
        {
            this.basketContext = basketContext;
            this.productContext = productContext;

        }

        private Basket GetBasket(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSession);

            Basket basket = new Basket();

            if (cookie != null)
            {
                string basketID = cookie.Value;
                if (!string.IsNullOrEmpty(basketID))    
                {
                    basket = basketContext.Find(basketID);
                }
                else
                {
                    if (createIfNull)   
                    {
                        basket = CreateNewBasket(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    basket = CreateNewBasket(httpContext);
                }
            }

            return basket;
        }

        private Basket CreateNewBasket(HttpContextBase httpContext)
        {
            Basket basket = new Basket();
            basketContext.Insert(basket);

            HttpCookie cookie = new HttpCookie(BasketSession);
            cookie.Value = basket.Id;
            cookie.Expires = DateTime.Now.AddDays(1);

            httpContext.Response.Cookies.Add(cookie);
            return basket;
        }


        public void AddToBasket(HttpContextBase httpContext, string productID)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItemCollection.FirstOrDefault(a => a.ProductID == productID);

            if (item == null)
            {
                item = new BasketItem()
                { BasketID = basket.Id, ProductID = productID, Quanity = 1 };

                basket.BasketItemCollection.Add(item);
            }
            else
            {
                item.Quanity = item.Quanity + 1;
            }

            basketContext.Commit();
        }


        public void RemoveFromBasket(HttpContextBase httpContext, string itemID)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItemCollection.FirstOrDefault(a => a.Id == itemID);

            if (item != null)   
            {
                basket.BasketItemCollection.Remove(item);
                basketContext.Commit();
            }

        }





    }
}
