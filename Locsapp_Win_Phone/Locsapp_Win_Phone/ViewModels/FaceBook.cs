using Facebook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;

namespace Locsapp_Win_Phone.ViewModels
{
    class FaceBook
    {
        private static string client_id = "1011661268854723";
        private static string scope = "email, public_profile, user_birthday";
        private string FacebookToken = "";
        private bool IsTokenGet = false;

        public string TokenFB
        {
            get { return FacebookToken; }
            set { FacebookToken = value; }
        }

        public bool isTokenGet
        {
            get { return IsTokenGet; }
            set { IsTokenGet = value; }
        }

        public async Task AuthenticateFacebookAsync()
        {
            var fb = new FacebookClient();
            var redirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();

            var loginUri = fb.GetLoginUrl(new
            {
                client_id = client_id,
                redirect_uri = redirectUri,
                scope = scope,
                display = "popup",
                response_type = "token"
            });

            var callbackUri = new Uri(redirectUri, UriKind.Absolute);
            var authenticationResult =
          await
            WebAuthenticationBroker.AuthenticateAsync(
            WebAuthenticationOptions.None,
            loginUri, callbackUri);
            FacebookToken = ParseAuthenticationResult(fb, authenticationResult);
            if (FacebookToken != "Error on http request" && FacebookToken != "User Cancel the operation")
            {
                IsTokenGet = true;
            }
        }

        private string ParseAuthenticationResult(FacebookClient fb, WebAuthenticationResult result)
        {
            switch (result.ResponseStatus)
            {
                case WebAuthenticationStatus.ErrorHttp:
                    return "Error on http request";
                case WebAuthenticationStatus.Success:
                    var oAuthResult = fb.ParseOAuthCallbackUrl(new Uri(result.ResponseData));
                    return oAuthResult.AccessToken;
                case WebAuthenticationStatus.UserCancel:
                    return "User Cancel the operation";
            }
            return null;
        }
    }
}
