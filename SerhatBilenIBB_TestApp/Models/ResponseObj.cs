using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatBilenIBB_TestApp.Models
{
    public class ResponseObj<T>
    {
        public bool status { get; set; }
        public string aciklama { get; set; }
        public string hatalar { get; set; }
        public T nesne { get; set; }
    }
}