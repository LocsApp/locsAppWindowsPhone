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

namespace Locsapp_Win_Phone.ViewModels
{
    class Collections
    {
        private RootPaymentMethod payementCol = null;
        private RootBaseCategory BCategoryCol = null;
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

            Debug.WriteLine("La base est " + BCategoryCol.Base_categories[0].name);
        }

        public static Collections Instance()
        {
            if (_instance == null)
                _instance = new Collections();
            return _instance;
        }

    }
}
