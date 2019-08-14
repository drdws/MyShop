using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using MyShop.Core.Contracts;
using WebUI.Controllers;

namespace WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRespository<ProductCategory> context;


        //public ProductCategoryManagerController(IRespository<ProductCategory> tproductCategory)
        //{
        //    this.context = tproductCategory;
        //}

        public ProductCategoryManagerController()
        {
            this.context = new InMemoryRespository<ProductCategory>();
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategory = context.Collection().ToList();
            return View(productCategory);
        }


        public ActionResult Create()
        {
            ProductCategory pc = new ProductCategory();
            return View(pc);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory pc)
        {
            if (!ModelState.IsValid)
            {
                return View(pc);
            }
            else
            {
                context.Insert(pc);
                context.Commit();

                return RedirectToAction("Index");
            }


        }

        public ActionResult Edit(string Id)
        {
            ProductCategory pc =  context.Find(Id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(pc);
            }

        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory pc = context.Find(Id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(pc);
                }
            }


            pc.Category = productCategory.Category;
            

            context.Commit();

            return RedirectToAction("Index");

        }


        public ActionResult Delete(string Id)
        {
            ProductCategory pc = context.Find(Id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(pc);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory pc = context.Find(Id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(pc.Id);
                context.Commit();
                return RedirectToAction("Index");

            }


        }
    }
}