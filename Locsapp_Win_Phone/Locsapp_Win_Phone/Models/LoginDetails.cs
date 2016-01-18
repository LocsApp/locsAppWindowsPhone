using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locsapp_Win_Phone.Models;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;

namespace Locsapp_Win_Phone.Models
{
    class SignUpDetails
    {
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
    }

    class UserInfos
    {
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        public string last_name { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public string birthdate { get; set; }
        public string phone { get; set; }
        public string living_address { get; set; }
        public string billing_address { get; set; }
        public string secondary_emails { get; set; }
        public string logo_url { get; set; }
        public string is_active { get; set; }
    }

    class LoginDetails
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    class Change_passwd
    {
        public string old_password { get; set; }
        public string new_password1 { get; set; }
        public string new_password2 { get; set; }
    }

    class Add_secondaryemail
    {
        public string new_email { get; set; }
    }

    class KeyRegister
    {
        [JsonProperty("key")]
        public string key { get; set; }
    }
}
