using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Specialized;
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
using Locsapp_Win_Phone.Models;
using Locsapp_Win_Phone.ViewModels;
using Newtonsoft;
using Newtonsoft.Json;

namespace Locsapp_Win_Phone
{
    public sealed partial class Profile : Page
    {
        private string _Key;

        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }


        public Profile()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string text = e.Parameter as string;
            Key = text;
            var API = new MainViewModel();
            API.API_req("http://192.168.198.130:8000/api/v1/rest-auth/user/", "GET", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API.SetResponse.ErrorMessage);
            if (API.SetResponse.error == false)
            {
                //Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);
                var results = JsonConvert.DeserializeObject<SignUpDetails>(API.SetResponse.APIResponseString);
                Hello.Text = Hello.Text + results.username;
                username.Text = username.Text + results.username;
                email.Text = email.Text + results.email;
            }
        }

    }
}
