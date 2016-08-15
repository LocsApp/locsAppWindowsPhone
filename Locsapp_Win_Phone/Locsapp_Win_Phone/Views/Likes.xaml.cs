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
        private List<FavoriteArticle>  FavoriteArt = new List<FavoriteArticle>();
        private Dictionary<string, string> DictSearch = new Dictionary<string, string>();
        private ObservableCollection<FavoritSearch> dataList = new ObservableCollection<FavoritSearch>();

        public Likes()
        {
            InitializeComponent();
            getdictcache();
            FavoriteSearch.ItemsSource = dataList;

            var API = new MainViewModel();
            var ses = SessionInfos.Instance();

            API.API_req(API.URL_API + "/api/v1/favorites/articles/", "GET", "", ses.GetKey());
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                var results = JsonConvert.DeserializeObject<FavoritesGet>(API.SetResponse.APIResponseString);
               // Debug.WriteLine("Le result est " + results.favorite_article[0]);
                FavoriteArticles.ItemsSource = results.favorite_article;
                FavoriteArt = results.favorite_article;
            }
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

        private void FavoriteArticles_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var Art = new ListSearchArticle();
            Art.Id = FavoriteArt[FavoriteArticles.SelectedIndex].id_article;
            Frame.Navigate(typeof(Article), Art);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var API = new MainViewModel();
            var ses = SessionInfos.Instance();
            var del = (Button)sender;

            string json = "{\"id_article\" : \"" + del.Tag + "\"}";
            Debug.WriteLine("Le Json est : " + json);
            API.API_req(API.URL_API + "/api/v1/favorites/delete-articles/", "POST", json, ses.GetKey());
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Frame.Navigate(typeof(Likes));
            }
        }
    }
}
