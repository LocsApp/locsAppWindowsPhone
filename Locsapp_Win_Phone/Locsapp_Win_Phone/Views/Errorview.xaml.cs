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
using Newtonsoft.Json.Linq;

namespace Locsapp_Win_Phone
{
    public sealed partial class Errorview : Page
    {

        private Dictionary<string, object> deserializeToDictionary(string jo)
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jo);
            var values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> d in values)
            {
                if (d.Value is JObject)
                {
                    values2.Add(d.Key, deserializeToDictionary(d.Value.ToString()));
                }
                else
                {
                    values2.Add(d.Key, d.Value);
                }
            }
            return values2;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainViewModel text = e.Parameter as MainViewModel;
            ErrorText.Text = text.SetResponse.ErrorMessage;
            ErrorJson.Text = "";
            if (text.SetResponse.JsonError != "")
            {
                Dictionary<string, object> values = deserializeToDictionary(text.SetResponse.JsonError);
                foreach (KeyValuePair<string, object> entry in values)
                {
                    ErrorJson.Text = ErrorJson.Text + entry.Key + " : " + entry.Value.ToString().Trim(new Char[] { '\n', '{', '}', '[', ']', '"' }) + '\n';
                }
            }
        }

        public Errorview()
        {
            this.InitializeComponent();
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
