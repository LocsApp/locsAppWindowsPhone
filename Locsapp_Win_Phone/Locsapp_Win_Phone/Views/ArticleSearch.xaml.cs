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

namespace Locsapp_Win_Phone
{
    public sealed partial class ArticleSearch : Page
    {
        
        public ArticleSearch()
        {
            this.InitializeComponent();
            ObservableCollection<SearchItems> dataList = new ObservableCollection<SearchItems>();

            SearchItems c1 = new SearchItems() { Price = "420 €", Title = "Robe rouge", Description = "Topkekus", Range = "Within 25 kms", Thumbnail = "ms-appx:///Assets/Article/Robe1Redim.jpg" };
            SearchItems c2 = new SearchItems() { Price = "40 €", Title = "Robe rouge number 2", Description = "lalalal", Range = "Within 45 kms", Thumbnail = "ms-appx:///Assets/Article/Robe2Redim.jpg" };
            SearchItems c3 = new SearchItems() { Price = "20 €", Title = "Robe rouge encore", Description = "Coucou les amis comment ça va ?", Range = "Within 75 kms", Thumbnail = "ms-appx:///Assets/Article/Robe3Redim.jpg" };
            SearchItems c4 = new SearchItems() { Price = "2 €", Title = "Robe rouge de test", Description = "Topkekrgregerus", Range = "Within 51 kms", Thumbnail = "ms-appx:///Assets/Article/Robe1Redim.jpg" };
            SearchItems c5 = new SearchItems() { Price = "201 €", Title = "Robe rouge et blanche", Description = "lalagegegelal", Range = "Within 568 kms", Thumbnail = "ms-appx:///Assets/Article/Robe2Redim.jpg" };
            SearchItems c6 = new SearchItems() { Price = "410 €", Title = "Robe rouge", Description = "Coucou comment ça va ?", Range = "Within 5 kms", Thumbnail = "ms-appx:///Assets/Article/Robe3Redim.jpg" };

            dataList.Add(c1);
            dataList.Add(c2);
            dataList.Add(c3);
            dataList.Add(c4);
            dataList.Add(c5);
            dataList.Add(c6);


            MyList.ItemsSource = dataList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FilterSearch));
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Article));
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ArticleSearch));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }
    }
}