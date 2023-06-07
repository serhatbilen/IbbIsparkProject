using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(SerhatBilenIBB_TestApp_API.App_Start.Startup))]

namespace SerhatBilenIBB_TestApp_API.App_Start
{
    public class Startup
    {
        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            // Configure Web API to use only bearer token authentication.  
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            ConfigureAuth(app);
            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the application for OAuth based flow  
            PublicClientId = "self";
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new AppOAuthProvider(PublicClientId),
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                // Üretimde olan mod kümesi AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            app.UseOAuthAuthorizationServer(OAuthOptions);//Oauth2 ayarlarinin yapilmasini saglar
            //Http request header'daki bearer token olup olmadigini anlamak icin kullanilir.
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
