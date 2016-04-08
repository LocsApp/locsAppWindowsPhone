using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locsapp_Win_Phone.Models;
using System.IO;
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
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;
namespace Locsapp_Win_Phone.Models
{
    class SearchModels
    {
    }

    class BuildSearchList
    {
        [JsonProperty("field_search")]
        public string FieldSearch { get; set; }
        [JsonProperty("check_search")]
        public bool CheckSearch { get; set; }
    }

    class BuildSearch
    {

        ObservableCollection<BuildSearchList> lists = new ObservableCollection<BuildSearchList>();

        public BuildSearch(string type = "")
        {
           switch (type)
            {
                case "State":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Well-Worn" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "A Little Used" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Minimal Wear" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Factory New" });
                    break;
                case "Payement":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Credit Card" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Paypal" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Cash" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Check" });
                    break;
                case "Category":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Disguse" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Sport" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Fancy" });
                    break;
                case "SubCategory":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Head" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Top" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Bottom" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Shoes" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Sets" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Accessories" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Others" });
                    break;
                case "Brand":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Channel" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Hermes" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Vuiton" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Lacoste" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Gucchi" });
                    break;
                case "Gender":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Man" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Woman" });
                    break;
                case "Size":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "XS" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "S" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "M" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "L" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "XL" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "2XL" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "3XL" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "4XL" });
                    break;
                case "Color":
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Red" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Green" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Blue" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Black" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "White" });
                    break;
                default:
                    lists.Add(new BuildSearchList { CheckSearch = true, FieldSearch = "Unknow Fields" });
                    break;
            }
        }

        public ObservableCollection<BuildSearchList> getlist()
        {
            return (lists);
        }

    }

}
