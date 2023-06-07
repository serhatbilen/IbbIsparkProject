using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;
using RestSharp;
using SerhatBilenIBB_TestApp.Models;
using SerhatBilenIBB_TestApp_API.Controllers;
using SerhatBilenIBB_TestApp_API.Models.ibb;

namespace SerhatBilenIBB_TestApp.Controllers
{
    public class IsparkController : Controller
    {
        // GET: Ispark
        public ActionResult Liste()
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

        [HttpPost]
        public ActionResult JsonDetay(string uid)
        {

            using (Definitions def = new Definitions())
            {
                System.Web.HttpCookie cookie = Request.Cookies["SBilenAuth"];
                if (cookie != null)
                {
                    var client = new RestClient(def.Servis + "/api/ispark/detay");
                    var request = new RestRequest(Method.POST);
                    request.AddParameter("Authorization", "Bearer " + cookie.Value, ParameterType.HttpHeader);
                    request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
                    request.AddParameter("", JsonConvert.SerializeObject(new { uid = uid }), ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ISPARKLAR isparkList = JsonConvert.DeserializeObject<ISPARKLAR>(response.Content);
                        return Json(isparkList);
                    }
                    return Json(new ISPARKLAR() { });
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }

        [HttpGet]
        public ActionResult Kaydet(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                return PartialView("_Ekle", new ISPARKLAR() { });
            }
            using (Definitions def = new Definitions())
            {
                System.Web.HttpCookie cookie = Request.Cookies["SBilenAuth"];
                if (cookie != null)
                {
                    var client = new RestClient(def.Servis + "/api/ispark/detay");
                    var request = new RestRequest(Method.POST);
                    request.AddParameter("Authorization", "Bearer " + cookie.Value, ParameterType.HttpHeader);
                    request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
                    request.AddParameter("", JsonConvert.SerializeObject(new { uid = uid }), ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ISPARKLAR isparkList = JsonConvert.DeserializeObject<ISPARKLAR>(response.Content);
                        return PartialView("_Ekle", isparkList);
                    }
                    return PartialView("_Ekle", new ISPARKLAR() { });
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }

        [HttpPost]
        public ActionResult Kaydet(ISPARKLAR model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        status = false,
                        aciklama = "Model Hatalı",
                        hatalar = string.Join("; ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))
                    });
                }
                else
                {
                    using (Definitions def = new Definitions())
                    {
                        System.Web.HttpCookie cookie = Request.Cookies["SBilenAuth"];
                        if (cookie != null)
                        {
                            var client = new RestClient(def.Servis + "/api/ispark/kaydet");
                            var request = new RestRequest(Method.POST);
                            request.AddParameter("Authorization", "Bearer " + cookie.Value, ParameterType.HttpHeader);
                            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
                            request.AddParameter("", JsonConvert.SerializeObject(model), ParameterType.RequestBody);
                            var response = client.Execute(request);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                return Json(JsonConvert.DeserializeObject<ResponseObj<ISPARKLAR>>(response.Content));
                            }
                            return Json(new { status = false });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(new { status = false });
        }

        [HttpPost]
        public ActionResult Sil(string uid)
        {
            using (Definitions def = new Definitions())
            {
                System.Web.HttpCookie cookie = Request.Cookies["SBilenAuth"];
                if (cookie != null)
                {
                    var client = new RestClient(def.Servis + "/api/ispark/sil");
                    var request = new RestRequest(Method.POST);
                    request.AddParameter("Authorization", "Bearer " + cookie.Value, ParameterType.HttpHeader);
                    request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
                    request.AddParameter("", JsonConvert.SerializeObject(new { uid = uid }), ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Json(JsonConvert.DeserializeObject<ResponseObj<ISPARKLAR>>(response.Content));
                    }
                    return Json(new { status = false });
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }
    }
}