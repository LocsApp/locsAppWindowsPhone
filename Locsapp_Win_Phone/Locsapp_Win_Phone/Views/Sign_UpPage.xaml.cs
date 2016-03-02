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
    public sealed partial class Sign_UpPage : Page
    {
        public Sign_UpPage()
        {
            this.InitializeComponent();
        }

        private void Button_Sub(object sender, RoutedEventArgs e)
        {
            SignUpDetails data = new SignUpDetails();
            data.email = email.Text;
            data.username  = username.Text;
            data.password1 = password1.Password;
            data.password2 = password2.Password;
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/registration/", "POST", json);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API);
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
    }
}