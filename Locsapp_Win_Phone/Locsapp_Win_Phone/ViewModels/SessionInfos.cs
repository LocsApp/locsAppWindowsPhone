﻿using System;
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
        private string Base_Url = "";
        private string User_Name = "";
        private string User_Notation = "";

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

        public void AddBaseUrl(string BaseUrl)
        {
            Base_Url = BaseUrl;
        }

        public string GetKey()
        {
            if (Key != "")
                return Key;
            else
                return ("No Key Found");
        }

        public string GetBaseUrl()
        {
            if (Base_Url != "")
                return Base_Url;
            else
                return ("No Base Url Found");
        }

    }
}
