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
        public Profile()
        {
            this.InitializeComponent();
            var API = new MainViewModel();
            string key = "97c0c8fdb37266ffc3f2fbfc9f4a5a3b24554151";    
            Debug.WriteLine("La clé de aute est : " + key);
            API.API_req("http://192.168.198.130:8000/api/v1/rest-auth/user/", "GET", "", key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API.SetResponse.ErrorMessage);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("Connection Success");
                Debug.WriteLine("La clé est : " + API.SetResponse.APIResponseString);
            } 
        }
    }
}
