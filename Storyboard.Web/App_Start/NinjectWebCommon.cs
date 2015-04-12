[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Storyboard.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Storyboard.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Storyboard.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Storyboard.Domain.Data;
    using Storyboard.Data.EF.Core;
    using Storyboard.Domain.Services;
    using HDLink;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<IStoryRepository>().To<StoryRepository>();
                kernel.Bind<IActorRepository>().To<ActorRepository>();
                kernel.Bind<IStoryReadService>().To<StoryReadService>();
                kernel.Bind<IAsyncLinkRepository>().To<LinkRepository>();
                kernel.Bind<ILinkDataService>().To<LinkDataService>();
                kernel.Bind<IAsyncNodeRepositoryFactory>().To<StoryboardNodeRepositoryFactory>();
                kernel.Bind<IAsyncNodeService>().To<AsyncNodeService>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
