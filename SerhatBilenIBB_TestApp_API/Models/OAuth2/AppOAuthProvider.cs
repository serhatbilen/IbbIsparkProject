using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SerhatBilenIBB_TestApp_API.Models.Kullanici;
using Serilog;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SerhatBilenIBB_TestApp_API
{
    public class AppOAuthProvider : OAuthAuthorizationServerProvider
    {
        public static string PublicClientId { get; private set; }
        public AppOAuthProvider(string id)
        {
            PublicClientId = id;
        }

        public override Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            return base.GrantCustomExtension(context);
        }

        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            return base.GrantClientCredentials(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Initialization.  
            //var user = await new LoginHelper().Login(context.UserName, context.Password);

            var data = await context.Request.ReadFormAsync();

            var user = (context.UserName == "serhat" && context.Password == "1234") ? new UserObj() { user_email = "serhatbilen1132@gmail.com", user_Guid = Guid.NewGuid(), user_lastname = "Bilen", user_name = "Serhat" } : null;

            //UserObj user = null;



            if (user == null)
            {
                context.SetError("invalid_grant", "Böyle bir kullanıcı bulunamadı");
                Log.Error("Hatalı Kullanıcı Girişi => {@user}", context.UserName);
                return;
            }
            /* Temsilci */
            UserObj representative = null;

            //new LogHelper().SaveUserLog(HttpContext.Current.Request.Browser.Browser, HttpContext.Current.Request.UserHostAddress, user.id);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, context.UserName),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var oAuthClaimIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
            var ticket = new AuthenticationTicket(oAuthClaimIdentity, CreateProperties(user, representative));
            context.Validated(ticket);
        }

        /// <summary>
        /// Accesss token generate olurken yani /token linkine post edildiginde CreateProperties metodunun donderdigi Map degeri json response da ekstra
        /// parametre olarak gonderilir.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="representative"></param>
        /// <returns></returns>
        public static AuthenticationProperties CreateProperties(UserObj user, UserObj representative)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                {"full_name", string.Concat(user.user_name, " ", user.user_lastname).TrimStart(' ').TrimEnd(' ') },
                {"email", user.user_email},
                {"user_login", "evet"},
                {"user_guid", user.user_Guid.ToString() }
            };
            return new AuthenticationProperties(data);
        }

        /// <summary>
        /// CreateProperties metodundaki parametrelere ek olarak baska parametreler eklemek icin kullanilabilir. Yine ayni sekilde /token linkine post edilince
        /// post sonucunda donen json da bu parametreler yer alacaktir.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Client Id leri validate etmek icin kullanilir. Bizim uygulamamızda 1 tane olduğu için context.Validated() demek yeterli olacaktır.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }

    public class AssignOAuth2SecurityRequirements : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Correspond each "Authorize" role to an oauth2 scope
            var scopes = apiDescription.ActionDescriptor.GetFilterPipeline()
                .Select(filterInfo => filterInfo.Instance)
                .OfType<AuthorizeAttribute>()
                .SelectMany(attr => attr.Roles.Split(','))
                .Distinct();

            if (scopes.Any())
            {
                if (operation.security == null)
                    operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
                {
                    { "oauth2", scopes }
                };

                operation.security.Add(oAuthRequirements);
            }
        }
    }
}