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
            data.username = "locsapp";
            data.password = "toto43";
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
            data.username = "locsapp";
            data.password = "toto43";
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
                API.API_req(API.URL_API + "api/v1/rest-auth/logout/", "POST", "", results.key);
                if (API.SetResponse.error == true)
                    Assert.Fail("Logout Failure");
                if (API.SetResponse.error == false)
                {
                    var result_logout = JsonConvert.DeserializeObject<Return_Logout>(API.SetResponse.APIResponseString);
                    Assert.AreEqual("Successfully logged out.", result_logout.success);
                }
            }
        }

        [TestMethod]
        public void TestChangeDataUser()
        {
            Locsapp_Win_Phone.Models.LoginDetails data = new Locsapp_Win_Phone.Models.LoginDetails();
            data.username = "locsapp";
            data.password = "toto43";
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
                data_user.first_name = "toto";
                data_user.last_name = "Tata";
                data_user.phone = "0612352624";
                string json_changedata = JsonConvert.SerializeObject(data_user);
                API.API_req(API.URL_API + "api/v1/rest-auth/user/", "PUT", json_changedata, results.key);
                if (API.SetResponse.error == true)
                    Assert.Fail("Change Data Failed");
                if (API.SetResponse.error == false)
                {
                    API.API_req(API.URL_API + "api/v1/rest-auth/user/", "GET", "", results.key);
                    if (API.SetResponse.error == true)
                        Assert.Fail("Get Data failure");
                    if (API.SetResponse.error == false)
                    {
                        var results_change = JsonConvert.DeserializeObject<UserInfos>(API.SetResponse.APIResponseString);
                        Assert.AreEqual("toto", results_change.first_name);
                    }
                }
             }
        }

        [TestMethod]
        public void TestChangePasswordUser()
        {
            Locsapp_Win_Phone.Models.LoginDetails data = new Locsapp_Win_Phone.Models.LoginDetails();
            data.username = "locsapp";
            data.password = "toto43";
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
                Change_passwd Pass = new Change_passwd();
                Pass.old_password = "toto43";
                Pass.new_password1 = "toto42";
                Pass.new_password2 = "toto42";
                string json_changepass = JsonConvert.SerializeObject(Pass);
                API.API_req(API.URL_API + "api/v1/rest-auth/user/", "PUT", json_changepass, results.key);
                if (API.SetResponse.error == true)
                    Assert.Fail("Change Data Failed");
                if (API.SetResponse.error == false)
                {
                    API.API_req(API.URL_API + "api/v1/rest-auth/password/change/", "POST", json_changepass, results.key);
                    if (API.SetResponse.error == true)
                        Assert.Fail("Get Change Password failure");
                    if (API.SetResponse.error == false)
                    {
                        Pass.old_password = "toto42";
                        Pass.new_password1 = "toto43";
                        Pass.new_password2 = "toto43";
                        json_changepass = JsonConvert.SerializeObject(Pass);
                        API.API_req(API.URL_API + "api/v1/rest-auth/password/change/", "POST", json_changepass, results.key);
                        Assert.AreEqual("1", "1");
                    }
                }
            }
        }
    }
}
