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

namespace Locsapp_Win_Phone
{
    public sealed partial class Article : Page
    {
        List<string> Images1 = new List<string>();
        List<string> Images2 = new List<string>();
        int imgCount = 0;
        int imgCountRec = 0;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListSearchArticle art = e.Parameter as ListSearchArticle;
            Price.Text = art.price;
            Description.Text = art.Description;
            Title.Text = art.Title;
        }

        public Article()
        {
            this.InitializeComponent();
            LoadSlideShow();
            //Description.Text = "This is a very pretty red dress\r\nRed, good idea for a party\r\nSuch happy with this dress !";
        }

        private void LoadSlideShow()
        {
            Images1.Add("Robe1Redim.jpg");
            Images1.Add("Robe2Redim.jpg");
            Images1.Add("Robe3Redim.jpg");
            Images2.Add("Robe1Redim.jpg");
            Images2.Add("Robe2Redim.jpg");
            Images2.Add("Robe3Redim.jpg");
        }

        private void SlidshowBack(object sender, RoutedEventArgs e)
        {
            imgCount++;
            if (imgCount >= Images1.Count)
                imgCount = 0;
            sceneriesBtn.Source = new BitmapImage(new Uri("ms-appx:///Assets/Article/" + Images1[imgCount]));
        }

        private void SlidshowForward(object sender, RoutedEventArgs e)
        {
            imgCount--;
            if (imgCount <= 0)
                imgCount = Images1.Count - 1;
            sceneriesBtn.Source = new BitmapImage(new Uri("ms-appx:///Assets/Article/" + Images1[imgCount]));
        }

        private void SlidshowBackRec(object sender, RoutedEventArgs e)
        {
            imgCountRec++;
            if (imgCountRec >= Images2.Count)
                imgCountRec = 0;
            recommand.Source = new BitmapImage(new Uri("ms-appx:///Assets/Article/" + Images2[imgCountRec]));
        }

        private void SlidshowForwardRec(object sender, RoutedEventArgs e)
        {
            imgCountRec--;
            if (imgCountRec <= 0)
                imgCountRec = Images2.Count - 1;
            recommand.Source = new BitmapImage(new Uri("ms-appx:///Assets/Article/" + Images2[imgCountRec]));
        }
    }
}
