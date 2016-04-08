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
    public sealed partial class State : Page
    {
        public State()
        {
            this.InitializeComponent();
            Debug.WriteLine("Salut les amis");
            ObservableCollection<BuildSearchList> lists = new ObservableCollection<BuildSearchList>();
            lists.Add(new BuildSearchList { CheckSearch = true, FieldSearch = "Well-Worn" });
            lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "A Little Used" });
            lists.Add(new BuildSearchList { CheckSearch = false, FieldSearch = "Minimal Wear" });
            lists.Add(new BuildSearchList { CheckSearch = true, FieldSearch = "Factory New" });
            MyList.ItemsSource = lists;
            Debug.WriteLine("Salut les amis 2");
        }
    }
}
