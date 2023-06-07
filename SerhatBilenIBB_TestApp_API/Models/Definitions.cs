using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Web;

namespace SerhatBilenIBB_TestApp_API.Models
{
    public class Definitions : IDisposable
    {
        System.Configuration.Configuration conf = null;

        private KeyValueConfigurationElement srv = null;
        private KeyValueConfigurationElement dbase = null;
        private KeyValueConfigurationElement usr = null;
        private KeyValueConfigurationElement pwd = null;

        public string Srv
        {
            get
            {
                string encodedText = srv.Value.ToString();
                SecureString secureString = new SecureString();
                encodedText.ToCharArray().ToList().ForEach(p => secureString.AppendChar(p));
                return SecureStringToString(secureString);
            }
        }

        public string DBase
        {
            get
            {
                string encodedText = dbase.Value.ToString();
                SecureString secureString = new SecureString();
                encodedText.ToCharArray().ToList().ForEach(p => secureString.AppendChar(p));
                return SecureStringToString(secureString);
            }
        }

        public string Usr
        {
            get
            {
                string encodedText = usr.Value.ToString();
                SecureString secureString = new SecureString();
                encodedText.ToCharArray().ToList().ForEach(p => secureString.AppendChar(p));
                return SecureStringToString(secureString);
            }
        }

        public string Pwd
        {
            get
            {
                string encodedText = pwd.Value.ToString();
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
            srv = conf.AppSettings.Settings["srv"];
            dbase = conf.AppSettings.Settings["dbase"];
            usr = conf.AppSettings.Settings["usr"];
            pwd = conf.AppSettings.Settings["pwd"];
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}