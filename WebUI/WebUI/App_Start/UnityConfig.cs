using MyShop.Core.Models;
using System.Web.Http;
using Unity;

using MyShop.Core.Contracts;
using MyShop.DataAccess.InMemory;
using Unity.AspNet.Mvc;

namespace WebUI
{
    public static class UnityConfig
    {
   

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
           // container.RegisterType<IRespository<Product>,InMemoryRespository<Product>>();
           // container.RegisterType<IRespository<ProductCategory>, InMemoryRespository<ProductCategory>>();

            // GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}