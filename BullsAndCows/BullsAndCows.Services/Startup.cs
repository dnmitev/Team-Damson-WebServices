using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject.Web.WebApi;
using Ninject.Web;
using System.Reflection;
using BullsAndCows.Data.Contracts;
using BullsAndCows.Data;
using BullsAndCows.GameLogic;
using BullsAndCows.Services.Infrastructure;

[assembly: OwinStartup(typeof(BullsAndCows.Services.Startup))]

namespace BullsAndCows.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        //private static StandardKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    RegisterMappings(kernel);
        //    return kernel;
        //}

        //private static void RegisterMappings(StandardKernel kernel)
        //{
        //    kernel.Bind<IBullsAndCowsData>().To<BullsAndCowsData>()
        //        .WithConstructorArgument("context", c => new BullsAndCowsDbContext());

        //    kernel.Bind<IGameDataValidator>().To<GameDataValidator>();

        //    kernel.Bind<IUserIdProvider>().To<AspUserIdProvider>();
        //}
    }
}
