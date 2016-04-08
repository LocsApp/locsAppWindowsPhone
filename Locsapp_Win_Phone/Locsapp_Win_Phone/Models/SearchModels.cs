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
                case "Brand":
                    lists.Add(new BuildSearchList { CheckSearch = true, FieldSearch = "Well-Worn" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "A Little Used" });
                    lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Minimal Wear" });
                    lists.Add(new BuildSearchList { CheckSearch = true, FieldSearch = "Factory New" });
                    break;
                default:
                    lists.Add(new BuildSearchList { CheckSearch = true, FieldSearch = "lel" });
                    break;
            }
        }

        public ObservableCollection<BuildSearchList> getlist()
        {
            return (lists);
        }

    }

}
