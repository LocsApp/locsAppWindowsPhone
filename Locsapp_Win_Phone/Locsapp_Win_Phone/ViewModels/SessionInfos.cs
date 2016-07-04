using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone.ViewModels
{
    class SessionInfos
    {
        private static SessionInfos _instance = null;
        private string Key = "";

        private SessionInfos()
        {
        }

        public static SessionInfos Instance()
        {
            if (_instance == null)
                _instance = new SessionInfos();
            return _instance;
        }

        public void AddKey(string key)
        {
            Key = key;
        }

        public string GetKey()
        {
            if (Key != "")
                return Key;
            else
                return ("No Key Found");
        }
    }
}
