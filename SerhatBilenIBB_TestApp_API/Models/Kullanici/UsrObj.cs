using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatBilenIBB_TestApp_API.Models.Kullanici
{
    public class UserObj
    {
        public Guid user_Guid { get; set; }
        public string user_name { get; set; }
        public string user_pwd { get; set; }
        public string user_lastname { get; set; }
        public string user_email { get; set; }
    }
}