using MyShop.Core.Models;
using System.Web.Http;
using Unity;
using MyShop.DataAccess.SQL;
using MyShop.Core.Contracts;
using MyShop.DataAccess.InMemory;
using Unity.AspNet.Mvc;
using Unity.WebApi;

namespace WebUI
{
    public static class UnityConfig
    {
        public static UnityContainer container;

        public static void RegisterComponents()
        {
           container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRespository<Product>, SQLRepository<Product>>();  // InMemoryRespository<Product>>();
            container.RegisterType<IRespository<ProductCategory>, SQLRepository<ProductCategory>>();  // InMemoryRespository<ProductCategory>>();

            // GlobalConfiguration.Configuration.DependencyResolver =  new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}