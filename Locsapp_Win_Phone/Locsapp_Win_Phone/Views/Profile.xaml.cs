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

        static string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
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
            API.API_req(API.URL_API + "/api/v1/rest-auth/user/", "GET", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);
                var results = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                Hello.Text = Hello.Text + " " +results.Username;
                username.Text = results.Username;
                email.Text = NullToString(results.Email);
                first_name.Text = NullToString(results.FirstName);
                last_name.Text = NullToString(results.LastName);
                phone_number.Text = NullToString(results.Phone);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserInfos data = new UserInfos();
            data.FirstName = first_name.Text;
            data.LastName = last_name.Text;
            data.Phone = phone_number.Text;
            data.Birthdate = birthday.Date.ToString("yyyy-MM-dd") + " 00:00:00";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/user/", "PUT", json, Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("OKAY : UpSuccess" + API.SetResponse.APIResponseString);
                /*Debug.WriteLine("Login Sucess");
                var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);*/
                Frame.Navigate(typeof(ProfileData), Key);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/logout/", "POST", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
                "LogOut Success",
                "Logout");

                var result = dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ChangePasswd json = new ChangePasswd();
            json.OldPassword = old.Password;
            json.NewPassword1 = new1.Password;
            json.NewPassword2 = new2.Password;
            string json2 = JsonConvert.SerializeObject(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/password/change/", "POST", json2, Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Frame.Navigate(typeof(ProfileData), Key);
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProfileData), Key);
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Profile), Key);
        }

    }
}
