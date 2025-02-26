﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.DataAccess.InMemory;
using WebUI.Controllers;

namespace WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
       IRespository<Product> context;
      IRespository<ProductCategory> productCategories;

        //public ProductManagerController(IRespository<Product> tproductContext, IRespository<ProductCategory> tproductCategory )
        //{
        //    context = tproductContext;
        //    productCategories = tproductCategory;
        //}

        public ProductManagerController()
        {
            context = new InMemoryRespository<Product>();
            productCategories = new InMemoryRespository<ProductCategory>();
        }


        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList<Product>();
            return View(products);
        }


        public ActionResult Create()
        {
            ProductManagerViewModel viewmodel  = new ProductManagerViewModel();


            viewmodel.product = new Product();
            viewmodel.productCategories = productCategories.Collection();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                if (file != null)
                {
                    product.Image = product.Id + System.IO.Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//" + product.Image));
                }

                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }


        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewmodel = new ProductManagerViewModel();
                viewmodel.product = product;
                viewmodel.productCategories = productCategories.Collection();
                return View(viewmodel);
                
            }

        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product p = context.Find(Id);
            if (p == null)  
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
            }


            p.Category = product.Category;
            p.Description = product.Description;
            p.Image = product.Image;
            p.Name = product.Name;
            p.Price = product.Price;

            context.Commit();

            return RedirectToAction("Index");

        }


        public ActionResult Delete(string Id)
        {
            Product p = context.Find(Id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(p);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product p = context.Find(Id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(p.Id);
                context.Commit();
                return RedirectToAction("Index");
                                
            }


        }

    }

    

}