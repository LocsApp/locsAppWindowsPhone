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

namespace Locsapp_Win_Phone
{
    public sealed partial class ArticleSearch : Page
    {
        
        public ArticleSearch()
        {
            this.InitializeComponent();
            ObservableCollection<SearchItems> dataList = new ObservableCollection<SearchItems>();

            SearchItems c1 = new SearchItems() { Price = "420", Title = "Salut les petits loups", Description = "Topkekus" };
            SearchItems c2 = new SearchItems() { Price = "42", Title = "Salut les petits amis", Description = "Lolilol" };
            SearchItems c3 = new SearchItems() { Price = "20", Title = "Salut les petits chats", Description = "Prongels" };


            dataList.Add(c1);

            dataList.Add(c2);

            dataList.Add(c3);

            MyList.ItemsSource = dataList;
        }

    }
}
