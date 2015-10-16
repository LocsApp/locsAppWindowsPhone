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

namespace Locsapp_Win_Phone.ViewModels
{
    class MainViewModel
    {
        private string _Data_JSON;

        public string Data_JSON
        {
            get { return _Data_JSON; }
            set { _Data_JSON = value; }
        }

        public void API_req(String API_URL, String Method, String JSON_data = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(API_URL);
            request.Method = Method;
            if (Method == "GET")
                request.BeginGetResponse(Response_Completed, request);
            if (Method == "POST")
            {
                request.ContentType = "text/json";
                Data_JSON = JSON_data;
                request.BeginGetRequestStream(Do_Request, request);
            }
        }

        void Do_Request(IAsyncResult result)
        {
            Debug.WriteLine(Data_JSON);
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            Stream postStream = request.EndGetRequestStream(result);
            byte[] byteArray = Encoding.UTF8.GetBytes(Data_JSON);
            postStream.Write(byteArray, 0, Data_JSON.Length);
            Debug.WriteLine(Data_JSON);
            request.BeginGetResponse(Response_Completed, request);
        }

        void Response_Completed(IAsyncResult result)
        {
            HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string res = streamReader.ReadToEnd();
            Debug.WriteLine(res);
        }

    }
}
