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

namespace Locsapp_Win_Phone
{
    public sealed partial class Article : Page
    {
        private string Id = "";
        private string Id_Author = "";
        private string name = "";
        private string thumb = "";
        List<string> Images1 = new List<string>();
        List<string> Images2 = new List<string>();
        int imgCount = 0;
        int imgCountRec = 0;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var collect = Collections.Instance();
            var ses = SessionInfos.Instance();
            var API = new MainViewModel();
            ListSearchArticle art = e.Parameter as ListSearchArticle;

            Id = art.Id;
            API.API_req(API.URL_API + "api/v1/articles/get/" + art.Id + "/", "GET", "", ses.GetKey());
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("LOL 3 ");
                    var results = JsonConvert.DeserializeObject<RootArticleFromGet>(API.SetResponse.APIResponseString);
                Debug.WriteLine("Le resukt est : " + results);
                Price.Text = results.article.price.ToString();
                if (string.IsNullOrEmpty(results.article.description))
                    Description.Text = "No describe for this article";
                else
                    Description.Text = results.article.description;
                Title.Text = results.article.title;
                name = results.article.title;
                MainCategory.Text = collect.GetNameFromId(results.article.base_category, "Category");
                SubCategory.Text = collect.GetNameFromId(results.article.sub_category, "SubCategory");
                Gender.Text = collect.GetNameFromId(results.article.gender, "genders");
                size.Text = collect.GetNameFromId(results.article.size, "sizes");
                color.Text = collect.GetNameFromId(results.article.color, "Color");
                brand.Text = collect.GetNameFromId(results.article.brand, "Brand");
                State.Text = collect.GetNameFromId(results.article.clothe_condition, "State");
                Author.Text = results.article.id_author.ToString();
                Id_Author = results.article.id_author.ToString();
                thumb = results.article.url_thumbnail;

                /* Traitement des images d'aperçu article */

                foreach (string apercu in results.article.url_pictures)
                {
                    Images1.Add(ses.GetBaseUrl() + apercu);
                    Debug.WriteLine("Ce qui a été ajouté est : " + ses.GetBaseUrl() + apercu.ToString());
                }

                Images2.Add(ses.GetBaseUrl() + results.article.url_thumbnail);
                Debug.WriteLine("Le thumbnail est : " + ses.GetBaseUrl() + results.article.url_thumbnail);
            }
        }

        public Article()
        {
            this.InitializeComponent();
        }

        private void SlidshowBack(object sender, RoutedEventArgs e)
        {
            imgCount++;
            if (imgCount >= Images1.Count)
                imgCount = 0;
            sceneriesBtn.Source = new BitmapImage(new Uri(Images1[imgCount]));
        }

        private void SlidshowForward(object sender, RoutedEventArgs e)
        {
            imgCount--;
            if (imgCount <= 0)
                imgCount = Images1.Count - 1;
            sceneriesBtn.Source = new BitmapImage(new Uri(Images1[imgCount]));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var API = new MainViewModel();
            var ses = SessionInfos.Instance();
            string json = "{\"id_article\" : \"" + Id + "\"}";
            API.API_req(API.URL_API + "/api/v1/favorites/articles/", "POST", json, ses.GetKey());
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
               "Success Add Favorite",
               "Favorite");

                var result = dialog.ShowAsync();
            }
        }

        private void SendQuestion(object sender, RoutedEventArgs e)
        {
            var ques = new QuestionToAsk();
            var API = new MainViewModel();
            var ses = SessionInfos.Instance();
            ques.id_article = Id;
            ques.content = AskQuestions.Text;
            if (AskQuestions.Text != "")
            {
                
                string json = JsonConvert.SerializeObject(ques);
                Debug.WriteLine("Le json est : " + json);
                API.API_req(API.URL_API + "/api/v1/articles/questions/", "POST", json, ses.GetKey());
                if (API.SetResponse.error == true)
                    Frame.Navigate(typeof(Errorview), API);
                if (API.SetResponse.error == false)
                {
                    var dialog = new Windows.UI.Popups.MessageDialog(
"Question send success",
"Question");

                    var result = dialog.ShowAsync();
                }
            }
            
        }

        private void Author_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var API = new MainViewModel();
            var ses = SessionInfos.Instance();
            API.API_req(API.URL_API + "/api/v1/user/" + "locsapp" + "/", "GET", "", ses.GetKey());
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
               "Success Add Favorite",
               "Favorite");

                var result = dialog.ShowAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("La demande est en cours");
            var API = new MainViewModel();
            var ses = SessionInfos.Instance();
            var demand = new DemandArticle();
            demand.article_thumbnail_url = thumb;
            demand.article_title = name;
            //demand.author_name;
            //demand.author_notation;
            //demand.availibility_end;
            //demand.availibility_start;
            string json = JsonConvert.SerializeObject(demand);
            API.API_req(API.URL_API + "/api/v1/articles/demands/", "POST", json, ses.GetKey());
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
                "Article demand sended",
                "Demande");

                var result = dialog.ShowAsync();
            }
        }
    }
}
