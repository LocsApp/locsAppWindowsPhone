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


// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Locsapp_Win_Phone
{

    public sealed partial class MainPage : Page
    {
        ///
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            LoginDetails data = new LoginDetails();
            data.username = Login.Text;
            data.password = Password.Password;
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req("http://192.168.198.130:8000/api/v1/rest-auth/login/", "POST", json);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API.SetResponse.ErrorMessage);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("Login Sucess");
                var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                Debug.WriteLine("La clé est + " + API.SetResponse.APIResponseString);
                Frame.Navigate(typeof(Profile), "97c0c8fdb37266ffc3f2fbfc9f4a5a3b24554151");
            } 
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
           Frame.Navigate(typeof(Sign_UpPage));
        }
    }
}
