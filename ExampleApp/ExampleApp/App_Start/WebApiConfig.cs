using ExampleApp.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ExampleApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            MediaTypeFormatter xmlFormatter = config.Formatters.XmlFormatter;
            (xmlFormatter as XmlMediaTypeFormatter).Indent = false;
            config.Formatters.Remove(xmlFormatter);
            config.Formatters.Insert(0, xmlFormatter);

            //JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            //jsonFormatter.Indent = true;
            //jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            //jsonFormatter.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            //jsonFormatter.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
        }
    }
}
