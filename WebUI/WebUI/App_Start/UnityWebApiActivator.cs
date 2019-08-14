using System.Web.Http;
using System.Configuration;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Extension;
using Unity.Factories;
using Unity.Injection;
using Unity.Microsoft.DependencyInjection;
using Unity.ObjectBuilder.BuildPlan;
using Unity.Policy;
using Unity.Processors;
using Unity.Registration;
using Unity.Resolution;
using Unity.Storage;
using Unity.Strategies;
using WebUI;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebUI.UnityWebApiActivator), nameof(WebUI.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebUI.UnityWebApiActivator), nameof(WebUI.UnityWebApiActivator.Shutdown))]

namespace WebUI
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
          //  var resolver = new UnityDependencyResolver(UnityConfig.container);

          //  GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
           // UnityConfig.container.Dispose();
        }
    }
}