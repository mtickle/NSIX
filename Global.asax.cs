using hbehr.recaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace NSIX
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string publicKey = "6Le7wTcUAAAAADO2qqMKCNywPrtBrZ-gL4aPfvBW";
            string secretKey = "6Le7wTcUAAAAANKfqDLKtvk-WoBXO89FriQ2uyf1";
            ReCaptcha.Configure(publicKey, secretKey);

            //Auto-select language from System.Thread.CurrentCulture
            ReCaptchaLanguage defaultLanguage = ReCaptchaLanguage.Auto;
            ReCaptcha.Configure(publicKey, secretKey, defaultLanguage);

        }
    }
}
