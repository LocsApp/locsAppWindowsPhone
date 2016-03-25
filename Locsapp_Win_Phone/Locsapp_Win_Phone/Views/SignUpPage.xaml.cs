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
using Windows.UI;

namespace Locsapp_Win_Phone
{
    public sealed partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private void Button_Sub(object sender, RoutedEventArgs e)
        {
            SignUpDetails data = new SignUpDetails();
            data.Email = email.Text;
            data.Username  = username.Text;
            data.Password1 = password1.Password;
            data.Password2 = password2.Password;
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/registration/", "POST", json);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
               var dialog = new Windows.UI.Popups.MessageDialog(
                 "Account succesfuly create ",
                 "Congratulation");

                var result = dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
                Debug.WriteLine("La clé est : " + API.SetResponse.APIResponseString);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFram = Window.Current.Content as Frame;
            if (rootFram != null && rootFram.CanGoBack)
            {
                rootFram.GoBack();
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (fb_username.Text == "")
            {
                fb_username.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                var Facebook = new FaceBook();
                await Facebook.AuthenticateFacebookAsync();
                if (Facebook.isTokenGet)
                {
                    var log_Facebook = new FaceBookRegister();
                    log_Facebook.FacebookToken = Facebook.TokenFB;
                    log_Facebook.Username = fb_username.Text;
                    string json = JsonConvert.SerializeObject(log_Facebook);
                    Debug.WriteLine(json);
                    var API = new MainViewModel();
                    API.API_req(API.URL_API + "api/v1/auth/facebook-register/", "POST", json);
                    Debug.WriteLine("OK1");
                    if (API.SetResponse.error == true)
                        Frame.Navigate(typeof(Errorview), API);
                    if (API.SetResponse.error == false)
                    {
                        Debug.WriteLine("OK2");
                        Debug.WriteLine("Key Get");
                        Debug.WriteLine(API.SetResponse.APIResponseString);
                        var dialog = new Windows.UI.Popups.MessageDialog(
                          "Account succesfuly create ",
                          "Congratulation"); ;
                    }
                }
                else
                {
                    var dialog = new Windows.UI.Popups.MessageDialog(
                        "Error on facebook Token",
                        "Facebook Error");
                    var result = dialog.ShowAsync();
                }
            }
        }
    }
}