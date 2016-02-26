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
    public sealed partial class Profil_Design : Page
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

        public Profil_Design()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
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
                View_Username.Text = results.username;
                View_Birthday.Text = results.birthdate;
                EditProfile_Email.Text = NullToString(results.email);
                EditProfile_FirstName.Text = NullToString(results.first_name);
                EditProfile_Name.Text = NullToString(results.last_name);
                EditProfile_Phone.Text = NullToString(results.phone);
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
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

        private void Send_Data(object sender, RoutedEventArgs e)
        {
            UserInfos data = new UserInfos();
            data.first_name = EditProfile_FirstName.Text;
            data.last_name = EditProfile_Name.Text;
            data.phone = EditProfile_Phone.Text;
            data.birthdate = EditProfile_Birthday.Date.ToString("yyyy-MM-dd") + " 00:00:00";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/user/", "PUT", json, Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("OKAY : UpSuccess" + API.SetResponse.APIResponseString);
                API = null;
                if (EditProfile_OldPass.Password != "")
                {
                    var API2 = new MainViewModel();
                    Change_passwd jsonPass = new Change_passwd();
                    jsonPass.old_password = EditProfile_OldPass.Password;
                    jsonPass.new_password1 = EditProfile_NewPass1.Password;
                    jsonPass.new_password2 = EditProfile_NewPass2.Password;
                    string json2 = JsonConvert.SerializeObject(jsonPass);
                    API2.API_req(API2.URL_API + "/api/v1/rest-auth/password/change/", "POST", json2, Key);
                    if (API2.SetResponse.error == true)
                        Frame.Navigate(typeof(Error_view), API2);
                    if (API2.SetResponse.error == false)
                    {
                        Frame.Navigate(typeof(Profil_Design), Key);
                    }
                }
                else
                {
                    Frame.Navigate(typeof(Profil_Design), Key);
                }
            }
        }

    }
}