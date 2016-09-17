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

namespace Locsapp_Win_Phone.ViewModels
{
    public class MainViewModel
    {
        //private static string URLAPI = "https://vxadvxkawm.localtunnel.me/";
        private static string URLAPI = "https://locsapp.sylflo.fr/";
        //private static string URLAPI = "http://151.80.38.31:8000/";
        //private static string URLAPI = "http://5.135.163.38:8010/";

        private string DataJSON;

        public string Data_JSON
        {
            get { return DataJSON; }
            set { DataJSON = value; }
        }

        public string URL_API
        {
            get { return URLAPI; }
        }

        public APIResponse SetResponse = new APIResponse(false, "");

        private static ManualResetEvent allDone = new ManualResetEvent(false);

        public void API_req(String API_URL, String Method, String JSON_data = "", String Key = "")
        {
            var ses = SessionInfos.Instance();
            ses.AddBaseUrl(URLAPI);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API_URL);
            request.Method = Method;
                allDone = new ManualResetEvent(false);
            if (Method == "GET")
            {
                if (Key != "")
                    request.Headers["Authorization"] = "Token " + Key;
                request.BeginGetResponse(Response_Completed, request);
                allDone.WaitOne();
            }
            if (Method == "PUT")
            {
                if (Key != "")
                    request.Headers["Authorization"] = "Token " + Key;
                request.ContentType = "application/json";
                Data_JSON = JSON_data;
                request.BeginGetRequestStream(new AsyncCallback(Do_Request), request);
                allDone.WaitOne();
            }
            if (Method == "POST")
            {
                if (Key != "")
                    request.Headers["Authorization"] = "Token " + Key;
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
                response = (HttpWebResponse)e.Response;
                SetResponse.error = true;
                SetResponse.ErrorMessage = e.Message;
               
                if (response != null)
                {
                    Stream streamResponse = response.GetResponseStream();

                    StreamReader streamRead = new StreamReader(streamResponse);

                    string responseString = streamRead.ReadToEnd();
                    Debug.WriteLine(response.Headers);

                    SetResponse.APIResponseString = responseString;

                    SetResponse.JsonError = responseString;

                    // Close the stream object
                    streamResponse.Dispose();
                    streamRead.Dispose();
                    // Release the HttpWebResponse
                    response.Dispose();
                }
                else
                {
                    SetResponse.APIResponseString = "Can't find API";
                    SetResponse.JsonError = "";
                }

            }
            if (SetResponse.error == false)
            {
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                string responseString = streamRead.ReadToEnd();
                Debug.WriteLine(response.Headers);

                SetResponse.APIResponseString = responseString;

                // Close the stream object
                streamResponse.Dispose();
                streamRead.Dispose();
                // Release the HttpWebResponse
                response.Dispose();
            }
            else
            {
                Debug.WriteLine("Error");
            }
            allDone.Set();
        }
    }
}
