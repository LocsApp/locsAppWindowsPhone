using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Locsapp_Win_Phone;
using Newtonsoft.Json;
using System.Diagnostics;
using Locsapp_Win_Phone.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoginUser()
        {
            Locsapp_Win_Phone.Models.LoginDetails data = new Locsapp_Win_Phone.Models.LoginDetails();
            data.Username = "locsapp";
            data.Password = "toto43";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new Locsapp_Win_Phone.ViewModels.MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/login/", "POST", json);
            if (API.SetResponse.error == true)
            {
                Assert.Fail("Login Failure");
            }
            if (API.SetResponse.error == false)
            {
                Assert.IsNotNull(API.SetResponse.APIResponseString, "Login Success");
            }
        }

        [TestMethod]
        public void TestLogoutUser()
        {
            Locsapp_Win_Phone.Models.LoginDetails data = new Locsapp_Win_Phone.Models.LoginDetails();
            data.Username = "locsapp";
            data.Password = "toto43";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new Locsapp_Win_Phone.ViewModels.MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/login/", "POST", json);
            if (API.SetResponse.error == true)
            {
                Assert.Fail("Login Failure");
            }
            if (API.SetResponse.error == false)
            {
                var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                API.API_req(API.URL_API + "api/v1/rest-auth/logout/", "POST", "", results.Key);
                if (API.SetResponse.error == true)
                    Assert.Fail("Logout Failure");
                if (API.SetResponse.error == false)
                {
                    var result_logout = JsonConvert.DeserializeObject<ReturnLogout>(API.SetResponse.APIResponseString);
                    Assert.AreEqual("Successfully logged out.", result_logout.Success);
                }
            }
        }

        [TestMethod]
        public void TestChangeDataUser()
        {
            Locsapp_Win_Phone.Models.LoginDetails data = new Locsapp_Win_Phone.Models.LoginDetails();
            data.Username = "locsapp";
            data.Password = "toto43";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new Locsapp_Win_Phone.ViewModels.MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/login/", "POST", json);
            if (API.SetResponse.error == true)
            {
                Assert.Fail("Login Failure");
            }
            if (API.SetResponse.error == false)
            {
                var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                UserInfos data_user = new UserInfos();
                data_user.FirstName = "toto";
                data_user.LastName = "Tata";
                data_user.Phone = "0612352624";
                string json_changedata = JsonConvert.SerializeObject(data_user);
                API.API_req(API.URL_API + "api/v1/rest-auth/user/", "PUT", json_changedata, results.Key);
                if (API.SetResponse.error == true)
                    Assert.Fail("Change Data Failed");
                if (API.SetResponse.error == false)
                {
                    API.API_req(API.URL_API + "api/v1/rest-auth/user/", "GET", "", results.Key);
                    if (API.SetResponse.error == true)
                        Assert.Fail("Get Data failure");
                    if (API.SetResponse.error == false)
                    {
                        var results_change = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                        Assert.AreEqual("toto", results_change.FirstName);
                    }
                }
             }
        }

        [TestMethod]
        public void TestChangePasswordUser()
        {
            Locsapp_Win_Phone.Models.LoginDetails data = new Locsapp_Win_Phone.Models.LoginDetails();
            data.Username = "locsapp";
            data.Password = "toto43";
            string json = JsonConvert.SerializeObject(data);
            Debug.WriteLine(json);
            var API = new Locsapp_Win_Phone.ViewModels.MainViewModel();
            API.API_req(API.URL_API + "api/v1/rest-auth/login/", "POST", json);
            if (API.SetResponse.error == true)
            {
                Assert.Fail("Login Failure");
            }
            if (API.SetResponse.error == false)
            {
                var results = JsonConvert.DeserializeObject<KeyRegister>(API.SetResponse.APIResponseString);
                ChangePasswd Pass = new ChangePasswd();
                Pass.OldPassword = "toto43";
                Pass.NewPassword1 = "toto42";
                Pass.NewPassword2 = "toto42";
                string json_changepass = JsonConvert.SerializeObject(Pass);
                API.API_req(API.URL_API + "api/v1/rest-auth/user/", "PUT", json_changepass, results.Key);
                if (API.SetResponse.error == true)
                    Assert.Fail("Change Data Failed");
                if (API.SetResponse.error == false)
                {
                    API.API_req(API.URL_API + "api/v1/rest-auth/password/change/", "POST", json_changepass, results.Key);
                    if (API.SetResponse.error == true)
                        Assert.Fail("Get Change Password failure");
                    if (API.SetResponse.error == false)
                    {
                        Pass.OldPassword = "toto42";
                        Pass.NewPassword1 = "toto43";
                        Pass.NewPassword2 = "toto43";
                        json_changepass = JsonConvert.SerializeObject(Pass);
                        API.API_req(API.URL_API + "api/v1/rest-auth/password/change/", "POST", json_changepass, results.Key);
                        Assert.AreEqual("1", "1");
                    }
                }
            }
        }
    }
}
