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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFram = Window.Current.Content as Frame;
            if (rootFram != null && rootFram.CanGoBack)
            {
                rootFram.GoBack();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            var active = new List<string>();
            var currentsearch = CurrentSearch.Instance();
            var collect = Collections.Instance();

            int i = 0;
            while (i != MyList.Items.Count)
            {
                BuildSearchList item = (BuildSearchList)MyList.Items[i];
                if (item.CheckSearch)
                    active.Add(collect.GetIdFromName(item.FieldSearch, type));
                i++;
            }
            currentsearch.AddCheckFields(active, type);
            Frame rootFram = Window.Current.Content as Frame;
            if (rootFram != null && rootFram.CanGoBack)
            {
                rootFram.GoBack();
            }
        }
    }
}
