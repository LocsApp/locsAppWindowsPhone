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
        [JsonProperty("birthdate")]
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
        [JsonProperty("tenant_score")]
        public int tenant_score { get; set; }
        [JsonProperty("gender")]
        public string gender { get; set; }
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
        [JsonProperty("_id")]
        public string Id { get; set; }
    }

    public class AddressDetails
    {
        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public int PostalCode { get; set; }
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }
    }

    public class AddressDisplay
    {
        [JsonProperty("alias", NullValueHandling = NullValueHandling.Ignore)]
        public string Alias { get; set; }
        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public int PostalCode { get; set; }
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> base_category { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> sub_category { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> gender { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> brand { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> clothe_condition { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> color { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> size { get; set; }
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
        public List<string> PaymentMethods { get; set; }
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
        public string price { get; set; }
        [JsonProperty("Brand")]
        public string brand { get; set; }
        [JsonProperty("id_author")]
        public int IdAuthor { get; set; }
        [JsonProperty("url_thumbnail")]
        public string UrlThumbnail { get; set; }
        [JsonProperty("url_pictures")]
        public List<string> UrlPictures { get; set; }
    }

    public class ListSearchResults
    {
        [JsonProperty("metadatas")]
        public ListSearchMetadatas Metadatas { get; set; }
        [JsonProperty("articles")]
        public List<ListSearchArticle> Articles { get; set; }
    }

    /* Notation */

    public class Notation
    {
        [JsonProperty("note")]
        public int Note { get; set; }
    }

    /* History */

    public class HistoryArticleList
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("history_type")]
        public string HistoryType { get; set; }
        [JsonProperty("url_thumbnail")]
        public string UrlThumbnail { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("accept")]
        public bool Accept { get; set; }
    }

    public class FavoritSearch
    {
        public string Name { get; set; }
    }


    /* Get articles infos From Get */

    public class AvailibilityEnd
    {
        [JsonProperty(PropertyName = "$date")]
        public long date { get; set; }
    }

    public class AvailibilityStart
    {
        [JsonProperty(PropertyName = "$date")]
        public long date { get; set; }
    }

    public class CreationDate
    {
        [JsonProperty(PropertyName = "$date")]
        public long date { get; set; }
    }

    public class Question
    {
        public bool visible { get; set; }
        public List<object> thumbs_up { get; set; }
        public int id_owner_article { get; set; }
        public string author_name { get; set; }
        public object response { get; set; }
        public List<object> report { get; set; }
        public string id { get; set; }
        public string content { get; set; }
        public string creation_date { get; set; }
    }

    public class ArticleFromGet
{
    public string _id { get; set; }
    public bool available { get; set; }
    public string availibility_end { get; set; }
    public string availibility_start { get; set; }
    public string base_category { get; set; }
    public string brand { get; set; }
    public string clothe_condition { get; set; }
    public string color { get; set; }
    public string creation_date { get; set; }
    public string description { get; set; }
    public string gender { get; set; }
    public int id_author { get; set; }
    public List<string> payment_methods { get; set; }
    public int price { get; set; }
    public string size { get; set; }
    public string sub_category { get; set; }
    public string title { get; set; }
    public List<string> url_pictures { get; set; }
    public string url_thumbnail { get; set; }
    public string username_author { get; set; }
    }

public class RootArticleFromGet
    {
        public int nb_mark_as_renter { get; set; }
        public List<object> articles_recommend { get; set; }
        public bool is_reported { get; set; }
        public int global_mark_as_renter { get; set; }
        public bool is_in_favorite { get; set; }
        public ArticleFromGet article { get; set; }
    }

    /* Favorites Get */

    public class FavoriteArticle
    {
        public string _id { get; set; }
        public CreationDate creation_date { get; set; }
        public string description { get; set; }
        public string id_article { get; set; }
        public int id_user { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public string url_thumbnail { get; set; }
        public string id_favorite_article { get; set; }
    }

    public class FavoritesGet
    {
        public List<FavoriteArticle> favorite_article { get; set; }
    }

    /* Questions */
    public class QuestionToAsk
    {
        public string content { get; set; }
        public string id_article { get; set; }
    }

    /* DemandeArticle */
    public class DemandArticle
    {
        public int id_target { get; set; } //id_author
        public string name_target { get; set; } //username_author
        public string id_article { get; set; } //id_article
        public string availibility_start { get; set; } //start
        public string availibility_end { get; set; } //end
        public string article_name { get; set; } //Title
        public string article_thumbnail_url { get; set; } //url_thumbnail
        public string author_name { get; set; } //current name
        public int author_notation { get; set; } //current notation

    }

}
