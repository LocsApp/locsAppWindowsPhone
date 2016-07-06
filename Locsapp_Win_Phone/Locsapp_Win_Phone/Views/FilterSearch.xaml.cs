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

    public sealed partial class FilterSearch : Page
    {

        public FilterSearch()
        {
            InitSearchCach();
            this.InitializeComponent();
        }

        private async void InitSearchCach()
        {
            Cache cach = new Cache();
        }

        private string GridToSearchScreen(int row)
        {
            string SearchScreen = "";

            switch (row)
            {
                case 1:
                    SearchScreen = "Category";
                    break;
                case 2:
                    SearchScreen = "SubCategory";
                    break;
                case 3:
                    SearchScreen = "Brand";
                    break;
                case 4:
                    SearchScreen = "Gender";
                    break;
                case 5:
                    SearchScreen = "Size";
                    break;
                case 6:
                    SearchScreen = "Color";
                    break;
                case 7:
                    SearchScreen = "State";
                    break;
                default:
                    SearchScreen = "Unknow";
                    break;
            }
            return SearchScreen;
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock grd = sender as TextBlock;
            int row = Grid.GetRow(grd);
            GridToSearchScreen(row);
            Frame.Navigate(typeof(SearchList), GridToSearchScreen(row));
        }

        private async void Grid_TappedPayement(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TitleSearch.Text != null)
            {
                var search = CurrentSearch.Instance();
                search.title = TitleSearch.Text;
            }
            Frame.Navigate(typeof(ArticleSearch));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var current = CurrentSearch.Instance();
            current.SaveCurrentSearch();
        }
    }
}
