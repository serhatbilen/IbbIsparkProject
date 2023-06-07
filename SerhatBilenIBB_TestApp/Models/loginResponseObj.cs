using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatBilenIBB_TestApp.Models
{
    public class loginResponseObj
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string user_login { get; set; }
        public string user_guid { get; set; }

        [JsonProperty(".issued")]
        public string issued { get; set; }

        [JsonProperty(".expires")]
        public string expires { get; set; }
    }
}