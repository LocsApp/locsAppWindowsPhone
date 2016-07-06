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
    public sealed partial class EditAdd : Page
    {

        public EditAdd()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var edit = Edit_Add.Instance();
            Alias.Text = edit.Add[edit.index][0];
            FName.Text = edit.Add[edit.index][1].Split('"')[15];
            LName.Text = edit.Add[edit.index][1].Split('"')[3];
            City.Text = edit.Add[edit.index][1].Split('"')[11];
            Address.Text = edit.Add[edit.index][1].Split('"')[7];
            PostalCode.Text = edit.Add[edit.index][1].Split('"')[18].TrimEnd('}').Trim().TrimStart(':');
        }

        public string BuildAddressToSend(string type = "")
        {
            string address =  "{\"first_name\" : \"";
            address += FName.Text;
            address += "\",\"last_name\" : \"";
            address += LName.Text;
            address += "\",\"address\" : \"";
            address += Address.Text;
            address += "\",\"postal_code\" : ";
            address += PostalCode.Text;
            address += ",\"city\" : \"";
            address += City.Text;
            address += "\"}";
            return address;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var key = SessionInfos.Instance();
            if (Alias.Text != "" && FName.Text != "" && LName.Text != "" && Address.Text != "" && City.Text != "")
            {
                string data = BuildAddressToSend("");
                var edit = Edit_Add.Instance();
                edit.Add[edit.index][0] = Alias.Text;
                edit.Add[edit.index][1] = data;

                Debug.WriteLine("Le data est : " + data);

                var API = new MainViewModel();

                if (edit.Type_Edit == "Living")
                    edit.data.LivingAddress = edit.Add;
                if (edit.Type_Edit == "Biling")
                    edit.data.BillingAddress = edit.Add;

                string json = JsonConvert.SerializeObject(edit.data);

                API.API_req(API.URL_API + "api/v1/rest-auth/user/", "PUT", json, key.GetKey());
                if (API.SetResponse.error == true)
                    Frame.Navigate(typeof(Errorview), API);
                if (API.SetResponse.error == false)
                {
                    Debug.WriteLine("Send Adrress Success");
                    Frame.Navigate(typeof(ProfilDesign), key.GetKey());
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
