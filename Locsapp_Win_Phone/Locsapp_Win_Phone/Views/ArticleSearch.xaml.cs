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

        public ListSearchArticle SelectArticle = new ListSearchArticle();

        public ArticleSearch()
        {
            
            this.InitializeComponent();

            SearchHandle();



        }

        private async void SearchHandle()
        {
            ObservableCollection<SearchItems> dataList = new ObservableCollection<SearchItems>();
            string Key = "";
            SearchItems c1 = new SearchItems();

            /*var search = CurrentSearch.Instance();

            search.JsonSearch();*/

            Debug.WriteLine("Search Article");

            var pre_json = new Pagination();
            pre_json.PageNumber = 1;
            pre_json.ItemsPerPage = 11;
            var json = new MetaDataSearch();
            json.Pagination = pre_json;
            json.Title = "";

            var search = CurrentSearch.Instance();
            

            var sesInfo = SessionInfos.Instance();
            Key = sesInfo.GetKey();

            var collect = Collections.Instance();

            string json2 = JsonConvert.SerializeObject(json);
            Debug.WriteLine("Le JSON est : " + json2);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/search/articles/", "POST", search.JsonSearch(), Key);
            if (API.SetResponse.error == true)
            {
                Debug.WriteLine("Il y a une erreur");
                Frame.Navigate(typeof(Errorview), API);
            }
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("OK !");
                var results = JsonConvert.DeserializeObject<ListSearchResults>(API.SetResponse.APIResponseString);
                Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);

                //Loop on result Search
                foreach (var item in results.Articles)
                {
                    Debug.WriteLine("La réponse est : " + item.Title);
                    c1.Title = item.Title;
                    c1.Price = item.price.ToString();
                    c1.Description = item.Description;
                    c1.Id = item.Id;
                    dataList.Add(c1);
                    c1 = new SearchItems();
                }
            }
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

        private void MyList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var select = (ListView)sender;
            var rawDataArticle = (SearchItems)select.SelectedItem;
            SelectArticle.Title = rawDataArticle.Title;
            SelectArticle.price = rawDataArticle.Price;
            SelectArticle.Description = rawDataArticle.Description;
            SelectArticle.Id = rawDataArticle.Id;
            Debug.WriteLine("L'Id de l'article est : " + SelectArticle.Id);
            Frame.Navigate(typeof(Article), SelectArticle);
        }
    }
}