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
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Locsapp_Win_Phone.ViewModels
{
    class Collections
    {
        private RootPaymentMethod payementCol = null;
        private RootBaseCategory BCategoryCol = null;
        private RootSubCategory SCategoryCol = null;
        private RootGendre GenderCol = null;
        private RootSizes SizeCol = null;
        private RootClothStates SClothCol = null;
        private RootClothColors CClothCol = null;
        private static Collections _instance = null;

        private Collections ()
        {
            string key = "";
            var sesInfo = SessionInfos.Instance();
            key = sesInfo.GetKey();
            var API = new MainViewModel();

            //Get Payement Methods
            API.API_req(API.URL_API + "api/v1/static-collections/payment-methods/", "GET", "", key);
            if (API.SetResponse.error == true)
                Debug.WriteLine("Error Get Payement");
            if (API.SetResponse.error == false)
                payementCol = JsonConvert.DeserializeObject<RootPaymentMethod>(API.SetResponse.APIResponseString);

            //Get BaseCategory
            API.API_req(API.URL_API + "api/v1/static-collections/base-categories/", "GET", "", key);
            if (API.SetResponse.error == true)
                Debug.WriteLine("Error Get Base Category");
            if (API.SetResponse.error == false)
                BCategoryCol = JsonConvert.DeserializeObject<RootBaseCategory>(API.SetResponse.APIResponseString);

            //Get SubCategory
            API.API_req(API.URL_API + "api/v1/static-collections/sub-categories/", "GET", "", key);
            if (API.SetResponse.error == true)
                Debug.WriteLine("Error Get Sub Category");
            if (API.SetResponse.error == false)
                SCategoryCol = JsonConvert.DeserializeObject<RootSubCategory>(API.SetResponse.APIResponseString);

            //Get Gender
            API.API_req(API.URL_API + "api/v1/static-collections/genders/", "GET", "", key);
            if (API.SetResponse.error == true)
                Debug.WriteLine("Error Get Gender");
            if (API.SetResponse.error == false)
                GenderCol = JsonConvert.DeserializeObject<RootGendre>(API.SetResponse.APIResponseString);

            //Get Sizes
            API.API_req(API.URL_API + "api/v1/static-collections/sizes/", "GET", "", key);
            if (API.SetResponse.error == true)
                Debug.WriteLine("Error Get Size");
            if (API.SetResponse.error == false)
                SizeCol = JsonConvert.DeserializeObject<RootSizes>(API.SetResponse.APIResponseString);

            //Get Cloths Colors
            API.API_req(API.URL_API + "api/v1/static-collections/clothe-colors/", "GET", "", key);
            if (API.SetResponse.error == true)
                Debug.WriteLine("Error Get Base Category");
            if (API.SetResponse.error == false)
                CClothCol = JsonConvert.DeserializeObject<RootClothColors>(API.SetResponse.APIResponseString);

            //Get States Cloths
            API.API_req(API.URL_API + "api/v1/static-collections/clothe-states/", "GET", "", key);
            if (API.SetResponse.error == true)
                Debug.WriteLine("Error Get Base Category");
            if (API.SetResponse.error == false)
                SClothCol = JsonConvert.DeserializeObject<RootClothStates>(API.SetResponse.APIResponseString);
        }

        public static Collections Instance()
        {
            if (_instance == null)
                _instance = new Collections();
            return _instance;
        }

        public string GetNameFromId(string ID, string category)
        {
            if (category == "base-categories" || category == "Category")
            {
                foreach (var item in BCategoryCol.Base_categories)
                {
                    if (item._id == ID)
                        return item.name;
                }
            }
            if (category == "sub-categories" || category == "SubCategory")
            {
                foreach (var item in SCategoryCol.sub_categories)
                {
                    if (item._id == ID)
                        return item.name;
                }
            }
            if (category == "genders" || category == "SubCategory")
            {
                foreach (var item in GenderCol.genders)
                {
                    if (item._id == ID)
                        return item.name;
                }
            }
            if (category == "sizes" || category == "Size")
            {
                foreach (var item in SizeCol.Sizes)
                {
                    if (item._id == ID)
                        return item.name;
                }
            }
            if (category == "clothe-colors" || category == "Color")
            {
                foreach (var item in CClothCol.clothe_colors)
                {
                    if (item._id == ID)
                        return item.name;
                }
            }
            if (category == "clothe-states" || category == "State")
            {
                foreach (var item in SClothCol.clothe_states)
                {
                    if (item._id == ID)
                        return item.name;
                }
            }
            if (category == "payement-methods" || category == "Payement")
            {
                foreach (var item in payementCol.payment_methods)
                {
                    if (item._id == ID)
                        return item.name;
                }
            }
            return "";
        }

        public string GetIdFromName(string Name, string category)
        {

            if (category == "base-categories" || category == "Category")
            {
                foreach (var item in BCategoryCol.Base_categories)
                {
                    if (item.name == Name)
                        return item._id;
                }
            }
            if (category == "sub-categories" || category == "SubCategory")
            {
                foreach (var item in SCategoryCol.sub_categories)
                {
                    if (item.name == Name)
                        return item._id;
                }
            }
            if (category == "genders" || category == "Gender")
            {
                foreach (var item in GenderCol.genders)
                {
                    if (item.name == Name)
                        return item._id;
                }
            }
            if (category == "sizes" || category == "Size")
            {
                foreach (var item in SizeCol.Sizes)
                {
                    if (item.name == Name)
                        return item._id;
                }
            }
            if (category == "clothe-colors" || category == "Color")
            {
                foreach (var item in CClothCol.clothe_colors)
                {
                    if (item.name == Name)
                        return item._id;
                }
            }
            if (category == "clothe-states" || category == "State")
            {
                foreach (var item in SClothCol.clothe_states)
                {
                    if (item.name == Name)
                        return item._id;
                }
            }
            if (category == "payement-methods" || category == "Payement")
            {
                foreach (var item in payementCol.payment_methods)
                {
                    if (item.name == Name)
                        return item._id;
                }
            }
            return "";
        }

        public ObservableCollection<BuildSearchList>  BuildSearchField(string type)
        {
            var currentserach = CurrentSearch.Instance();
            ObservableCollection<BuildSearchList> lists = new ObservableCollection<BuildSearchList>();

            if (type == "Category")
            {
                foreach (var item in BCategoryCol.Base_categories)
                    lists.Add(new BuildSearchList { CheckSearch = currentserach.IsCheck(item.name, "Category"), FieldSearch = item.name });
            }
            if (type == "SubCategory")
            {
                foreach (var item in SCategoryCol.sub_categories)
                    lists.Add(new BuildSearchList { CheckSearch = currentserach.IsCheck(item.name, "SubCategory"), FieldSearch = item.name });
            }
            if (type == "Gender")
            {
                foreach (var item in GenderCol.genders)
                    lists.Add(new BuildSearchList { CheckSearch = currentserach.IsCheck(item.name, "Gender"), FieldSearch = item.name });
            }
            if (type == "Size")
            {
                foreach (var item in SizeCol.Sizes)
                    lists.Add(new BuildSearchList { CheckSearch = currentserach.IsCheck(item.name, "Size"), FieldSearch = item.name });
            }
            if (type == "Color")
            {
                foreach (var item in CClothCol.clothe_colors)
                    lists.Add(new BuildSearchList { CheckSearch = currentserach.IsCheck(item.name, "Color"), FieldSearch = item.name });
            }
            if (type == "State")
            {
                foreach (var item in SClothCol.clothe_states)
                    lists.Add(new BuildSearchList { CheckSearch = currentserach.IsCheck(item.name, "State"), FieldSearch = item.name });
            }
            if (type == "Payement")
            {
                foreach (var item in payementCol.payment_methods)
                    lists.Add(new BuildSearchList { CheckSearch = currentserach.IsCheck(item.name, "Payement"), FieldSearch = item.name });
            }
            return lists;
        }

    }
}
