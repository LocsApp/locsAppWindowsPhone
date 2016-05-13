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

namespace Locsapp_Win_Phone.Models
{
    public class SignUpDetails
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password1")]
        public string Password1 { get; set; }
        [JsonProperty("password2")]
        public string Password2 { get; set; }
    }

    public class UserInfos
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password1")]
        public string Password1 { get; set; }
        [JsonProperty("password2")]
        public string Password2 { get; set; }
        [JsonProperty("birthday")]
        public string Birthdate { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("living_address")]
        public List<List<string>> LivingAddress { get; set; }
        [JsonProperty("billing_address")]
        public List<List<string>> BillingAddress { get; set; }
        [JsonProperty("secondary_emails")]
        public object SecondaryEmails { get; set; }
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
        [JsonProperty("is_active")]
        public string IsActive { get; set; }
        [JsonProperty("registered_date")]
        public string RegisteredDate { get; set; }
    }

    public class LoginDetails
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class ChangeUserName
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class ChangePasswd
    {
        [JsonProperty("old_password")]
        public string OldPassword { get; set; }
        [JsonProperty("new_password1")]
        public string NewPassword1 { get; set; }
        [JsonProperty("new_password2")]
        public string NewPassword2 { get; set; }
    }

    public class KeyRegister
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    }

    public class FaceBookRegister
    {
        [JsonProperty("facebook_token")]
        public string FacebookToken { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class FaceBookLogin
    {
        [JsonProperty("facebook_token")]
        public string FacebookToken { get; set; }
    }

    //{"message": "Facebook login done", "key": "8dd25509b11768138bced77a4c03327e5990a561", "id": 2}
    public class FaceBookKey
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class ReturnLogout
    {
        [JsonProperty("success")]
        public string Success { get; set; }
    }

    public class SearchItems
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Range { get; set; }
        public string Thumbnail { get; set; }
    }

    public class AddressDetails
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("postal_code")]
        public int PostalCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }

    public class AddressDisplay
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("postal_code")]
        public int PostalCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }

    public class AddAddressContext
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("iduser")]
        public string IdUser { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("page_number")]
        public int PageNumber { get; set; }
        [JsonProperty("items_per_page")]
        public int ItemsPerPage { get; set; }
    }

    public class MetaDataSearch
    {
        [JsonProperty("_pagination")]
        public Pagination Pagination { get; set; }
    }


    /* Resultat Search Article */

    public class ListSearchMetadatas
    {
        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
        [JsonProperty("page_number")]
        public int PageNumber { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }

    public class ListSearchArticle
    {
        [JsonProperty("availibility_start")]
        public string AvailibilityStart { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("base_category")]
        public string BaseCategory { get; set; }
        [JsonProperty("article_state")]
        public string ArticleState { get; set; }
        [JsonProperty("creation_date")]
        public string CreationDate { get; set; }
        [JsonProperty("payment_methods")]
        public string PaymentMethods { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("availibility_end")]
        public string AvailibilityEnd { get; set; }
        [JsonProperty("clothe_condition")]
        public string ClotheCondition { get; set; }
        [JsonProperty("sub_category")]
        public string SubCategory { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("Price")]
        public int price { get; set; }
        [JsonProperty("Brand")]
        public string brand { get; set; }
        [JsonProperty("id_author")]
        public int IdAuthor { get; set; }
        [JsonProperty("url_thumbnail")]
        public string UrlThumbnail { get; set; }
    }

    public class ListSearchResults
    {
        [JsonProperty("metadatas")]
        public ListSearchMetadatas Metadatas { get; set; }
        [JsonProperty("articles")]
        public List<ListSearchArticle> Articles { get; set; }
    }

}
