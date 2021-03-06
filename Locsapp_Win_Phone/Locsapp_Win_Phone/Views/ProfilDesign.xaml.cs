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


namespace Locsapp_Win_Phone
{
    public sealed partial class ProfilDesign : Page
    {

        private string _Key;
        private string _Id;
        private List<List<string>> LivingListList;
        private List<List<string>> BilingListList;
        private List<AddressDisplay> _LivingList;
        private List<AddressDisplay> _BillingList;

        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        static string NullToString(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }

        public ProfilDesign()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void InitAddress(List<List<string>> Living, List<List<string>> Billing)
        {
            List<AddressDisplay> LivingList = new List<AddressDisplay>();
            List<AddressDisplay> BillingList = new List<AddressDisplay>();
            if (Living != null)
            {
                foreach (List<string> Field in Living)
                {
                    var results = JsonConvert.DeserializeObject<AddressDisplay>(Field[1]);
                    results.Alias = Field[0];
                    LivingList.Add(results);
                }
                LivingListView.ItemsSource = LivingList;
                _LivingList = LivingList;
            }
            if (Billing != null)
            {
                foreach (List<string> Field in Billing)
                {
                    var results = JsonConvert.DeserializeObject<AddressDisplay>(Field[1]);
                    results.Alias = Field[0];
                    BillingList.Add(results);
                }
                BilingListView.ItemsSource = BillingList;
                _BillingList = BillingList;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string text = e.Parameter as string;
            Key = text;

            //Save Key in Cache
            var sesinfo = SessionInfos.Instance();
            sesinfo.AddKey(Key);


            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/user/", "GET", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("La réponse est : " + API.SetResponse.APIResponseString);
                var results = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                Id = results.Id;
                sesinfo.AddUserName(results.Username);
                sesinfo.AddUserNotation(results.tenant_score.ToString());
                View_Username.Text = results.Username;
                View_Birthday.Text = NullToString(results.Birthdate);
                Debug.WriteLine("La date reçu est : " + results.Birthdate);
                View_Subscribed.Text = NullToString(results.RegisteredDate);
                EditProfile_Email.Text = NullToString(results.Email);
                EditProfile_FirstName.Text = NullToString(results.FirstName);
                EditProfile_Name.Text = NullToString(results.LastName);
                EditProfile_Phone.Text = NullToString(results.Phone);
                LivingListList = results.LivingAddress;
                BilingListList = results.BillingAddress;
                InitAddress(results.LivingAddress, results.BillingAddress);
                Debug.WriteLine("L'url du logo est : " + NullToString(results.LogoUrl));
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/logout/", "POST", "", Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
                "LogOut Success",
                "Logout");

                var result = dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void Send_Data(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SEND DATAAAAA");
            UserInfos data = new UserInfos();
            data.FirstName = EditProfile_FirstName.Text;
            data.LastName = EditProfile_Name.Text;
            data.Phone = EditProfile_Phone.Text;
            data.Birthdate = EditProfile_Birthday.Date.ToString("yyyy/MM/dd");
            Debug.WriteLine("La birthday envoyée est : " + data.Birthdate);
            //data.Birthdate = EditProfile_Birthday.Date.ToString("yyyy-");
            if (EditProfile_Man.IsChecked == true)
                data.gender = "Male";
            if (EditProfile_Woman.IsChecked == true)
                data.gender = "Woman";
            data.LivingAddress = LivingListList;
            data.BillingAddress = BilingListList;
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/user/", "PUT", json, Key);
            if (API.SetResponse.error == true)
                Frame.Navigate(typeof(Errorview), API);
            if (API.SetResponse.error == false)
            {
                Debug.WriteLine("OKAY : UpSuccess" + API.SetResponse.APIResponseString);
                API = null;
                if (EditProfile_OldPass.Password != "")
                {
                    var API2 = new MainViewModel();
                    ChangePasswd jsonPass = new ChangePasswd();
                    jsonPass.OldPassword = EditProfile_OldPass.Password;
                    jsonPass.NewPassword1 = EditProfile_NewPass1.Password;
                    jsonPass.NewPassword2 = EditProfile_NewPass2.Password;
                    string json2 = JsonConvert.SerializeObject(jsonPass);
                    API2.API_req(API2.URL_API + "api/v1/rest-auth/password/change/", "POST", json2, Key);
                    if (API2.SetResponse.error == true)
                        Frame.Navigate(typeof(Errorview), API2);
                    if (API2.SetResponse.error == false)
                    {
                        Frame.Navigate(typeof(ProfilDesign), Key);
                    }
                }
                else
                {
                    Frame.Navigate(typeof(ProfilDesign), Key);
                }
            }
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Article));
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ArticleSearch));
        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Likes));
        }

        private void AddAddressBilling(object sender, RoutedEventArgs e)
        {
            AddAddressContext billing = new AddAddressContext();
            billing.IdUser = Id;
            billing.Key = Key;
            billing.Type = "billing";
            Frame.Navigate(typeof(AddAddress), billing);
        }

        private void AddAddressLiving(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("L'Id qui est envoyé est : " + Id);
            AddAddressContext living = new AddAddressContext();
            living.IdUser = Id;
            living.Key = Key;
            living.Type = "living";
            Frame.Navigate(typeof(AddAddress), living);
        }

        private void DeleteAddress(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int i2 = 0;
            bool is_find = false;
            var del = (Button)sender;
            foreach (List<string> item in LivingListList)
            {
                if (item[0] == del.Tag.ToString())
                {
                    is_find = true;
                    i2 = i;
                }  
                i++;
            }
            if (is_find)
                LivingListList.RemoveAt(i2);
            Send_Data(null, null);
        }

        private void DeleteAddressBiling(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int i2 = 0;
            bool is_find = false;
            var del = (Button)sender;
            foreach (List<string> item in BilingListList)
            {
                if (item[0] == del.Tag.ToString())
                {
                    is_find = true;
                    i2 = i;
                }
                i++;
            }
            if (is_find)
                BilingListList.RemoveAt(i2);
            Send_Data(null, null);
        }

        private void EditAddress(object sender, RoutedEventArgs e)
        {
            var Edit = Edit_Add.Instance();
            int i = 0;
            int i2 = 0;
            bool is_find = false;
            var del = (Button)sender;
            foreach (List<string> item in LivingListList)
            {
                if (item[0] == del.Tag.ToString())
                {
                    is_find = true;
                    i2 = i;
                }
                i++;
            }
            if (is_find)
            {
                UserInfos data = new UserInfos();
                data.FirstName = EditProfile_FirstName.Text;
                data.LastName = EditProfile_Name.Text;
                data.Phone = EditProfile_Phone.Text;
                data.Birthdate = EditProfile_Birthday.Date.ToString("yyyy-MM-dd") + " 00:00:00";
                data.LivingAddress = LivingListList;
                data.BillingAddress = BilingListList;
                Edit.index = i2;
                Edit.Add = LivingListList;
                Edit.data = data;
                Edit.Type_Edit = "Living";
                Frame.Navigate(typeof(EditAdd));
            }
        }

        private void EditAddressBiling(object sender, RoutedEventArgs e)
        {
            var Edit = Edit_Add.Instance();
            int i = 0;
            int i2 = 0;
            bool is_find = false;
            var del = (Button)sender;
            foreach (List<string> item in BilingListList)
            {
                if (item[0] == del.Tag.ToString())
                {
                    is_find = true;
                    i2 = i;
                }
                i++;
            }
            if (is_find)
            {
                UserInfos data = new UserInfos();
                data.FirstName = EditProfile_FirstName.Text;
                data.LastName = EditProfile_Name.Text;
                data.Phone = EditProfile_Phone.Text;
                data.Birthdate = EditProfile_Birthday.Date.ToString("yyyy-MM-dd") + " 00:00:00";
                data.LivingAddress = LivingListList;
                data.BillingAddress = BilingListList;
                Edit.index = i2;
                Edit.Add = BilingListList;
                Edit.data = data;
                Edit.Type_Edit = "Biling";
                Frame.Navigate(typeof(EditAdd));
            }
        }

        private async void Upload_profile_pic(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
               Debug.WriteLine("Picked photo: " + file.Name);
            }
            else
            {
                Debug.WriteLine("Canceled");
            }
        }
    }
}