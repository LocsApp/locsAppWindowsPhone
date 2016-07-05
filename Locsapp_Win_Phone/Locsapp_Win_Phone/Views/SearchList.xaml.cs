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
using System.Collections.ObjectModel;
using Windows.Storage;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone
{
    public sealed partial class SearchList : Page
    {

        private string type = "Unknown";

        public SearchList()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            type = e.Parameter as string;
            var Collect = Collections.Instance();

            MyList.ItemsSource = Collect.BuildSearchField(type);
        }

        public async Task checkFromCache()
        {
            int i = 0;
            int i2 = 0;

            //Cache cach = new Cache();
                Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
                //dic = await cach.get("CurrentSearch");
                if (dic.ContainsKey(type))
                {
                    while (i != dic[type].Count)
                    {
                        while (i2 != MyList.Items.Count)
                        {
                            BuildSearchList item = (BuildSearchList)MyList.Items[i2];
                            if (item.FieldSearch == dic[type][i])
                            {
                                item.CheckSearch = true;
                                Debug.WriteLine("Ok : " + dic[type][i]);
                            }
                            i2++;
                        }
                        i2 = 0;
                        i++;
                    } 
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

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            //Cache cach = new Cache();
            var Data = new Dictionary<string, List<string>>();
            var active = new List<string>();
            int i = 0;
            while (i != MyList.Items.Count)
            {
                BuildSearchList item = (BuildSearchList)MyList.Items[i];
                if (item.CheckSearch)
                    active.Add(item.FieldSearch);
                i++;
            }
            Data.Add(type, active);
            //await cach.Save("CurrentSearch", Data);
            Frame rootFram = Window.Current.Content as Frame;
            if (rootFram != null && rootFram.CanGoBack)
            {
                rootFram.GoBack();
            }
        }
    }
}
