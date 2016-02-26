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
using Facebook;


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
            if (Login.Text != "" && Password.Password != "")
            {
                LoginDetails data = new LoginDetails();
                data.username = Login.Text;
                data.password = Password.Password;
                string json = JsonConvert.SerializeObject(data);
                Debug.WriteLine(json);
                var API = new MainViewModel();
                API.API_req(API.URL_API + "/api/v1/rest-auth/login/", "POST", json);
                if (API.SetResponse.error == true)
                    Frame.Navigate(typeof(Error_view), API);
                if (API.SetResponse.error == false)
                {
                    Debug.WriteLine("Login Sucess");
                    Debug.WriteLine(API.SetResponse.APIResponseString);
                    var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                    Frame.Navigate(typeof(Profil_Design), results.key);
                }
            }
            if (Login.Text == "")
                Login.BorderBrush = new SolidColorBrush(Colors.Red);
             if (Password.Password == "")
                Password.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
           Frame.Navigate(typeof(Sign_UpPage));
        }

        private void Verify_UserName_Facebook(string key)
        {
            Debug.WriteLine(key);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "/api/v1/rest-auth/user/", "GET", "", key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Error_view), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);
                var results = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                if (results.username == "")
                {
                    Debug.WriteLine("Le username est Vide");
                    Debug.WriteLine("Creation d'un username");
                    ChangeUserName jsonUsername = new ChangeUserName();
                    jsonUsername.username = "Maxou";
                    string json2 = JsonConvert.SerializeObject(jsonUsername);
                    API.API_req(API.URL_API + "/api/v1/auth/change-username/", "POST", json2, key);
                }
                else
                {
                    Debug.WriteLine("Le username est Plein");
                    Debug.WriteLine("On peut Logger");
                }
            }
        }

        private void Sign_Up_Facebook(object sender, RoutedEventArgs e)
        {
               var log_Facebook = new FaceBook_Login();
               log_Facebook.access_token = "CAACEdEose0cBAItTfiAm0N6Qhk67TcOzTaioBUF5ppYsIUvbYe0mJjEHJwJK2Re7kXVZA4cYLZAelw2XwP9GiZBg5aFrTRd835vZC76oCyce87kFo17l6Vjw40s3F1bbxPkYrzaweY8Nwa8aRrG1kFyd9oDABApCncFQcul0TgfOA4ZCRSuFjZCZB7JslKKALxWSRkmxqNUCQZDZD";
               log_Facebook.code = "1011661268854723";
               string json = JsonConvert.SerializeObject(log_Facebook);
               Debug.WriteLine(json);
               var API = new MainViewModel();
               API.API_req(API.URL_API + "/api/v1/rest-auth/facebook/", "POST", json);
               if (API.SetResponse.error == true)
                   Frame.Navigate(typeof(Error_view), API);
               if (API.SetResponse.error == false)
               {
                   Debug.WriteLine("Key Get");
                   Debug.WriteLine(API.SetResponse.APIResponseString);
                    var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                    Verify_UserName_Facebook("7f8dc0807745bb376735439078f6e441bc1bda87");
               }
            //Verify_UserName_Facebook("719887c9b84003367ef388ae11ced9497405dff9");
        }
        }


    }
