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
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Sign_UpPage : Page
    {
        ///
        public Sign_UpPage()
        {
            this.InitializeComponent();
        }

        private void Button_Sub(object sender, RoutedEventArgs e)
        {
            SignUpDetails data = new SignUpDetails();
            data.email = email.Text;
            data.first_name = first_name.Text;
            data.username  = username.Text;
            data.password1 = password1.Password;
            data.password2 = password2.Password;
            data.birthday = "12/07/1994";
            data.phone = phone.Text;
            data.living_adress = l_adress.Text;
            data.biling_adress = b_adress.Text;
            data.logo_url = "kek/";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            //var API = new MainViewModel();
            //API.API_req("http://127.0.0.1:8000/api/v1/rest-auth/login/", "POST", json);
        }
    }
}