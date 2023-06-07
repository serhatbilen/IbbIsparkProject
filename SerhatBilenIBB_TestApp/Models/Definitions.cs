﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Web;

namespace SerhatBilenIBB_TestApp.Models
{
    public class Definitions : IDisposable
    {
        System.Configuration.Configuration conf = null;

        private KeyValueConfigurationElement servis = null;


        public string Servis
        {
            get
            {
                string encodedText = servis.Value.ToString();
                SecureString secureString = new SecureString();
                encodedText.ToCharArray().ToList().ForEach(p => secureString.AppendChar(p));
                return SecureStringToString(secureString);
            }
        }

        

        String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public Definitions()
        {
            conf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            servis = conf.AppSettings.Settings["servisLinki"];
            //dbase = conf.AppSettings.Settings["dbase"];
            //usr = conf.AppSettings.Settings["usr"];
            //pwd = conf.AppSettings.Settings["pwd"];

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}