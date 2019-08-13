using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;

        public ProductManagerController()
        {
                       

        }


        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().to
            return View();
        }
    }
}