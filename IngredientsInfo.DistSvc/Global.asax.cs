using IngredientsInfo.DistSvc.IoC;
using IngredientsService;
using System;
using System.Web;

namespace IngredientsInfo.DistSvc
{
    public class WCFIngredientsApplication : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ((StructureMap.Container)Singleton.Container).Configure(
                config => config.AddRegistry<StructureMapRegistry>()
            );

            AutomapperInitializer.ConfigureMappings();
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }
    }
}