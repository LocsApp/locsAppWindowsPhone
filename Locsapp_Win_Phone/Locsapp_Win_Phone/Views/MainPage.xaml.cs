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
using Windows.Security.Authentication.Web;
using Windows.ApplicationModel.Store;


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
                data.Username = Login.Text;
                data.Password = Password.Password;
                string json = JsonConvert.SerializeObject(data);
                Debug.WriteLine(json);
                var API = new MainViewModel();
                API.API_req(API.URL_API + "api/v1/rest-auth/login/", "POST", json);
                if (API.SetResponse.error == true)
                    Frame.Navigate(typeof(Errorview), API);
                if (API.SetResponse.error == false)
                {
                    Debug.WriteLine("Login Sucess");
                    Debug.WriteLine(API.SetResponse.APIResponseString);
                    var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                    Frame.Navigate(typeof(ProfilDesign), results.Key);
                }
            }
            if (Login.Text == "")
                Login.BorderBrush = new SolidColorBrush(Colors.Red);
             if (Password.Password == "")
                Password.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
           Frame.Navigate(typeof(SignUpPage));
        }

        private void Verify_UserName_Facebook(string key, FaceBookLogin log_Facebook)
        {
            Debug.WriteLine(key);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/user/", "GET", "", key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);
                var results = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                if (results.Username == "")
                {
                    Debug.WriteLine("Le username est Vide");
                    Debug.WriteLine("Creation d'un username");
                    if (Login.Text == "")
                    {
                        Login.BorderBrush = new SolidColorBrush(Colors.Red);
                        new Windows.UI.Popups.MessageDialog( "Please insert a Username", "Username");
                    }
                    else
                    {
                        ChangeUserName jsonUsername = new ChangeUserName();
                        jsonUsername.Username = Login.Text;
                        string json2 = JsonConvert.SerializeObject(jsonUsername);
                        API.API_req(API.URL_API + "api/v1/auth/change-username/", "POST", json2, key);
                        Debug.WriteLine("Change Username OK");
                        string json = JsonConvert.SerializeObject(log_Facebook);
                        API.API_req(API.URL_API + "api/v1/rest-auth/facebook/", "POST", json);
                        if (API.SetResponse.error == true)
                            Frame.Navigate(typeof(Errorview), API);
                        if (API.SetResponse.error == false)
                        {
                            Debug.WriteLine("Key Get");
                            Debug.WriteLine(API.SetResponse.APIResponseString);
                            var key_login = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                            Frame.Navigate(typeof(ProfilDesign), key_login);
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Le username est Plein");
                    Debug.WriteLine("On peut Logger");
                    Frame.Navigate(typeof(ProfilDesign), key);
                }
            }
        }

        private async void Sign_Up_Facebook(object sender, RoutedEventArgs e)
        {
            var Facebook = new FaceBook();
            await Facebook.AuthenticateFacebookAsync();
            if (Facebook.isTokenGet)
            {
                var log_Facebook = new FaceBookLogin();
                Debug.WriteLine("Le token utilisé est : " + Facebook.TokenFB);
                log_Facebook.FacebookToken = Facebook.TokenFB;
                string json = JsonConvert.SerializeObject(log_Facebook);
                Debug.WriteLine(json);
                var API = new MainViewModel();
                API.API_req(API.URL_API + "api/v1/auth/facebook-login/", "POST", json);
                Debug.WriteLine("OK1");
                if (API.SetResponse.error == true)
                    Frame.Navigate(typeof(Errorview), API);
                if (API.SetResponse.error == false)
                {
                    Debug.WriteLine("OK2");
                    Debug.WriteLine("Key Get");
                    Debug.WriteLine(API.SetResponse.APIResponseString);
                    var key_login = JsonConvert.DeserializeObject<FaceBookKey>(API.SetResponse.APIResponseString);
                    Frame.Navigate(typeof(ProfilDesign), key_login.Key);
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
