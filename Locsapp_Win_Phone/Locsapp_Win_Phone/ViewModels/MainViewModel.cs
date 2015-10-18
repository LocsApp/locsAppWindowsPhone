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

        private static ManualResetEvent allDone = new ManualResetEvent(false);

        public void API_req(String API_URL, String Method, String JSON_data = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API_URL);
            request.Method = Method;
            if (Method == "GET")
                request.BeginGetResponse(Response_Completed, request);
            if (Method == "POST")
            {
                request.ContentType = "application/json";
                Data_JSON = JSON_data;
                request.BeginGetRequestStream(new AsyncCallback(Do_Request), request);
                allDone.WaitOne();
            }
        }

        void Do_Request(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            request.Accept = "*/*";
            request.Credentials = CredentialCache.DefaultCredentials;
            Stream postStream = request.EndGetRequestStream(result);
            byte[] byteArray = Encoding.UTF8.GetBytes(Data_JSON);
            postStream.Write(byteArray, 0, Data_JSON.Length);
            postStream.Dispose();
            request.BeginGetResponse(new AsyncCallback(Response_Completed), request);
        }

        void Response_Completed(IAsyncResult result)
        {
            var _Cookie = new CookieContainer();

            ///TODO CRFS Token
            /// 

            ///
            ///X-CSRFToken : <le token CSRF>
            ///Authorization : Token <le token renvoyé par le endpoint login>
            /// Envoyez donc bien "is_active"  : "True"


            HttpWebResponse response = null;
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            request.CookieContainer = _Cookie;
            request.Accept = "*/*";
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                response = (HttpWebResponse)request.EndGetResponse(result);
            }
            catch (WebException e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.Response);
            }
            Debug.WriteLine(response.Headers);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
            Debug.WriteLine(responseString);
            // Close the stream object
            streamResponse.Dispose();
            streamRead.Dispose();

            // Release the HttpWebResponse
            response.Dispose();
            allDone.Set();
        }
    }
}
