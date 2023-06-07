using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SerhatBilenIBB_TestApp.Models;

namespace SerhatBilenIBB_TestApp.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
            System.Web.HttpCookie cookie = Request.Cookies["SBilenAuth"];
            if (cookie != null)
            {
                return RedirectToAction("Index", "Home");
            }

            // giriş sayfası
            return View(new LoginViewModel());
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel login)
        {
            using (Definitions def = new Definitions())
            {

                var tokenClient = new RestClient(def.Servis + "/Token");
                var tokenRequest = new RestRequest(Method.POST);
                tokenRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                tokenRequest.AddParameter("grant_type", "password");
                tokenRequest.AddParameter("username", login.KullaniciAdi);
                tokenRequest.AddParameter("password", login.Parola);

                var tokenResponse = tokenClient.Execute(tokenRequest);
                if (tokenResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    loginResponseObj resp = JsonConvert.DeserializeObject<loginResponseObj>(tokenResponse.Content);
                    System.Web.HttpCookie cookie = new System.Web.HttpCookie("SBilenAuth");
                    cookie.Value = resp.access_token;
                    cookie.Expires = DateTime.Now.AddSeconds(resp.expires_in);
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message= "<div class='alert alert-danger' role='alert'>Kullanıcı adı veya parola bilgisi hatalı </div>";
                }
            }
            return View(login);
        }


        public ActionResult Cikis()
        {

            if (Request.Cookies["SBilenAuth"] != null)
            {
                System.Web.HttpCookie httpCookie = new System.Web.HttpCookie("SBilenAuth")
                {
                    Expires = DateTime.Now.AddYears(-1)
                };
                Response.Cookies.Add(httpCookie);
            }

            return RedirectToAction("Index", "Login");
        }


    }
}