using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locsapp_Win_Phone.Models;
using Locsapp_Win_Phone.ViewModels;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;

namespace Locsapp_Win_Phone.ViewModels
{
    //Handle Errors

    class API_Response
    {
        public Boolean _IsError;
        public string _ErrorMessage;
        public string _APIResponseString;
        public string _JsonError;

        public Boolean error
        {
            get { return _IsError; }
            set { _IsError = value; }
        }

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }

        public string APIResponseString
        {
            get { return _APIResponseString; }
            set { _APIResponseString = value; }
        }

        public API_Response(Boolean Iserror, string message)
        {
            error = Iserror;
            if (error == true)
                ErrorMessage = message;
            else
                APIResponseString = message;
        }

        public string JsonError
        {
            get { return _JsonError; }
            set { _JsonError = value; }
        }
    }
}
