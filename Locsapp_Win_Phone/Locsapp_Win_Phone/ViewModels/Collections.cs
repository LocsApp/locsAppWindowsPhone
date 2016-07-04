using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone.ViewModels
{
    class Collections
    {

        private static Collections _instance = null;

        private Collections ()
        {
            //var API = new MainViewModel();
            //Debug.WriteLine("La route utilisée est : " + API.URL_API + APIRoute);
            //API.API_req(API.URL_API + APIRoute, "POST", data, secretKey);
            //if (API.SetResponse.error == true)
            //    Frame.Navigate(typeof(Errorview), API);
            //if (API.SetResponse.error == false)
            //{
            //    Debug.WriteLine("Send Adrress Success");
            //    Frame.Navigate(typeof(ProfilDesign), secretKey);
            //}
        }

        public static Collections Instance()
        {
            if (_instance == null)
                _instance = new Collections();
            return _instance;
        }

    }
}
