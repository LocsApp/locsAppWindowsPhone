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
    public sealed partial class Profile_Data : Page
    {
        private string _Key;

        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }


        public Profile_Data()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string text = e.Parameter as string;
            Key = text;
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/user/", "GET", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);
                var results = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                Hello.Text = Hello.Text + " " + results.username;
                username.Text = username.Text + " " + results.username;
                email.Text = email.Text + " " +  results.email;
                first_name.Text = first_name.Text + " " + results.first_name;
                last_name.Text = last_name.Text + " " + results.last_name;
                phone_number.Text = phone_number.Text + " " + results.phone;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserInfos data = new UserInfos();
            data.first_name = first_name.Text;
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/user/", "PUT", json, Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("OKAY : UpSuccess" + API.SetResponse.APIResponseString);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/logout/", "POST", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API);
            if (API.SetResponse.error == false)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
                "LogOut Success",
                "Logout");

                var result = dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}