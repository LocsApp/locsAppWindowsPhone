﻿using System;
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

namespace Locsapp_Win_Phone
{
    public sealed partial class SearchList : Page
    {

        private string type = "Unknown";

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            type = e.Parameter as string;
            MyList.ItemsSource = new BuildSearch(type).getlist();
            MyList.UpdateLayout();
        }

        public SearchList()
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

        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            Cache cach = new Cache();
            /*var Data = new Dictionary<string, List<string>>();
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
            await cach.Save("CurrentSearch", Data);*/
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            dic = await cach.get("CurrentSearch");
            Debug.WriteLine(dic[type][0]);
            Frame rootFram = Window.Current.Content as Frame;
            if (rootFram != null && rootFram.CanGoBack)
            {
                rootFram.GoBack();
            }
        }

    }
}
