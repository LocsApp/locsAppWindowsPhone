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
using System.Threading.Tasks;

namespace Locsapp_Win_Phone
{
    public sealed partial class Likes : Page
    {
        private List<string> SearchJson = new List<string>();
        private Dictionary<string, string> DictSearch = new Dictionary<string, string>();
        private ObservableCollection<FavoritSearch> dataList = new ObservableCollection<FavoritSearch>();

        public Likes()
        {
            InitializeComponent();
            getdictcache();
            FavoriteSearch.ItemsSource = dataList;
        }

        private async void getdictcache()
        {
            FavoritSearch favSearch = new FavoritSearch();
            Cache cach = new Cache();
            if (await cach.isCacheExist("SavedSearchCache"))
            {
                DictSearch = await cach.get("SavedSearchCache");
                Debug.WriteLine("Le nombre de fav ets : " + DictSearch.Count);

                foreach (KeyValuePair<string, string> item in DictSearch)
                {
                    favSearch.Name = item.Key;
                    dataList.Add(favSearch);
                    SearchJson.Add(item.Value);
                }
            }

            
            FavoriteSearch.ItemsSource = dataList;
        }

        private void FavoriteSearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var current = CurrentSearch.Instance();

            if (FavoriteSearch.SelectedIndex != -1)
            {
                current.FromSaveSearch = true;
                current.SavedSearch = SearchJson[FavoriteSearch.SelectedIndex];

                Frame.Navigate(typeof(ArticleSearch));
            }

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Cache cach = new Cache();
            await cach.Save("SavedSearchCache", new Dictionary<string, string>());
            Frame.Navigate(typeof(Likes));
        }
    }
}
