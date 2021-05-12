using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BurgerBuilder.WebApi
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			GlobalConfiguration.Configuration.EnableCors();

			GlobalConfiguration.Configuration.Routes.Add("default", new HttpRoute("{controller}/{action}"));
			GlobalConfiguration.Configuration.Routes.Add("imageRoute", new HttpRoute("{controller}/{action}/{name}/{format}"));

			GlobalConfiguration.Configuration.Formatters.RemoveAt(1);
			Repository.Configuration.RegisterEntities();
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}