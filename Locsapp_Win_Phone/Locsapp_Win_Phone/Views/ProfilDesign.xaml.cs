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
    public sealed partial class ProfilDesign : Page
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

        public ProfilDesign()
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
            API.API_req(API.URL_API + "api/v1/rest-auth/user/", "GET", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);
                var results = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                View_Username.Text = results.Username;
                View_Birthday.Text = NullToString(results.Birthdate);
                View_Subscribed.Text = NullToString(results.RegisteredDate);
                EditProfile_Email.Text = NullToString(results.Email);
                EditProfile_FirstName.Text = NullToString(results.FirstName);
                EditProfile_Name.Text = NullToString(results.LastName);
                EditProfile_Phone.Text = NullToString(results.Phone);
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/logout/", "POST", "", Key);
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

        private void Send_Data(object sender, RoutedEventArgs e)
        {
            UserInfos data = new UserInfos();
            data.FirstName = EditProfile_FirstName.Text;
            data.LastName = EditProfile_Name.Text;
            data.Phone = EditProfile_Phone.Text;
            data.Birthdate = EditProfile_Birthday.Date.ToString("yyyy-MM-dd") + " 00:00:00";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/user/", "PUT", json, Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("OKAY : UpSuccess" + API.SetResponse.APIResponseString);
                API = null;
                if (EditProfile_OldPass.Password != "")
                {
                    var API2 = new MainViewModel();
                    ChangePasswd jsonPass = new ChangePasswd();
                    jsonPass.OldPassword = EditProfile_OldPass.Password;
                    jsonPass.NewPassword1 = EditProfile_NewPass1.Password;
                    jsonPass.NewPassword2 = EditProfile_NewPass2.Password;
                    string json2 = JsonConvert.SerializeObject(jsonPass);
                    API2.API_req(API2.URL_API + "api/v1/rest-auth/password/change/", "POST", json2, Key);
                    if (API2.SetResponse.error == true)
                        Frame.Navigate(typeof(Errorview), API2);
                    if (API2.SetResponse.error == false)
                    {
                        Frame.Navigate(typeof(ProfilDesign), Key);
                    }
                }
                else
                {
                    Frame.Navigate(typeof(ProfilDesign), Key);
                }
            }
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            var API2 = new MainViewModel();
            /*
            {
    "billing_address" : [ "alias",
    {
        "first_name" : "lol",
        "last_name" : "kek",
        "address" : "12 rue des allahuakbar",
        "postal_code" : 76888,
        "city" : "Paris"
    }]
}

            */
            string address = "{\"billing_address\" : [ \"";
            address += "Maison";
            address += "\",{\"first_name\" : \"";
            address += "Maxime";
            address += "\",\"last_name\" : \"";
            address += "Duboy";
            address += "\",\"address\" : \"";
            address += "Topkek City 155";
            address += "\",\"postal_code\" : ";
            address += "64600";
            address += ",\"city\" : \"";
            address += "Parius";
            address += "\"}]}";
            Debug.WriteLine(address);
            API2.API_req(API2.URL_API + "api/v1/user/1/billing_addresses/", "POST", address, Key);
            if (API2.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API2);
            if (API2.SetResponse.error == false)
            {
                Frame.Navigate(typeof(ProfilDesign), Key);
            }
            //Debug.Write(json2);
            //Frame.Navigate(typeof(Article));
        }
    }
}