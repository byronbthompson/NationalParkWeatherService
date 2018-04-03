using Capstone.Web.Models.DAL;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Capstone.Web
{
    public class MvcApplication : NinjectHttpApplication
    {

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            string connectionString = ConfigurationManager.ConnectionStrings["ParkWeatherGeek"].ConnectionString;

            kernel.Bind<IParkDAL>().To<ParkSQLDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IWeatherDAL>().To<WeatherSQLDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<ISurveyDAL>().To<SurveySQLDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}
