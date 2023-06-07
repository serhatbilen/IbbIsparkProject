using Newtonsoft.Json;
using RestSharp;
using SerhatBilenIBB_TestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerhatBilenIBB_TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (Definitions def = new Definitions())
            {
                System.Web.HttpCookie cookie = Request.Cookies["SBilenAuth"];
                if (cookie != null)
                {
                    var client = new RestClient(def.Servis + "/api/ispark/liste");
                    var request = new RestRequest(Method.GET);
                    request.AddParameter("Authorization", "Bearer " + cookie.Value, ParameterType.HttpHeader);

                    var response = client.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<ISPARKLAR> isparkList = JsonConvert.DeserializeObject<List<ISPARKLAR>>(response.Content);
                        return View(isparkList);
                    }
                    return View(new List<ISPARKLAR>() { });
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

        }
    }
}