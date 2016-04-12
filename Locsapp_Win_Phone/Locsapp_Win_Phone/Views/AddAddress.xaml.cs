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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;

namespace Locsapp_Win_Phone
{
    public sealed partial class AddAddress : Page
    {

        private string type_adrress = "";
        private string secretKey = "";
        private string id = "toto";

        public AddAddress()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AddAddressContext context = e.Parameter as AddAddressContext;
            id = context.IdUser;
            type_adrress = context.Type;
            Title.Text = "Add " + context.Type + " Address";
            secretKey = context.Key;
        }

        public string BuildAddressToSend( string type = "")
        {
            string address = "{\"";
            address += type;
            address += "_address\" : [ \"";
            address += Alias.Text;
            address += "\",{\"first_name\" : \"";
            address += FName.Text;
            address += "\",\"last_name\" : \"";
            address += LName.Text;
            address += "\",\"address\" : \"";
            address += Address.Text;
            address += "\",\"postal_code\" : ";
            address += PostalCode.Text;
            address += ",\"city\" : \"";
            address += City.Text;
            address += "\"}]}";
            return address;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Alias.Text != "" && FName.Text != "" && LName.Text != "" && Address.Text != "" && City.Text != "")
            {
                string APIRoute = "api/v1/user/" + id + "/" + type_adrress + "_addresses/";
                string data = BuildAddressToSend(type_adrress);
                Debug.WriteLine(data);
                var API = new MainViewModel();
                Debug.WriteLine("La route utilisée est : " + API.URL_API + APIRoute);
                API.API_req(API.URL_API + APIRoute, "POST", data, secretKey);
                if (API.SetResponse.error == true)
                    Frame.Navigate(typeof(Errorview), API);
                if (API.SetResponse.error == false)
                {
                    Debug.WriteLine("Send Adrress Success");
                    Frame.Navigate(typeof(ProfilDesign), secretKey);
                }
            }
            else
            {
                if (Alias.Text == "")
                    Alias.BorderBrush = new SolidColorBrush(Colors.Red);
                if (FName.Text == "")
                    FName.BorderBrush = new SolidColorBrush(Colors.Red);
                if (LName.Text == "")
                    LName.BorderBrush = new SolidColorBrush(Colors.Red);
                if (Address.Text == "")
                    Address.BorderBrush = new SolidColorBrush(Colors.Red);
                if (City.Text == "")
                    City.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
