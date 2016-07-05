using Locsapp_Win_Phone.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone.ViewModels
{
    class CurrentSearch
    {
        private static CurrentSearch _instance = null;
        public string title = "";
        public List<string> base_category = new List<string>();
        public List<string> sub_category = new List<string>();
        public List<string> gender = new List<string>();
        public List<string> brand = new List<string>();
        public List<string> clothe_condition = new List<string>();
        public List<string> color = new List<string>();
        public List<string> size = new List<string>();

        private CurrentSearch()
        {
        }

        public static CurrentSearch Instance()
        {
            if (_instance == null)
                _instance = new CurrentSearch();
            return _instance;
        }

        public bool IsCheck(string Name, string Category)
        {
            var Collect = Collections.Instance();

            if (Category == "Category")
                if (base_category.Contains(Collect.GetIdFromName(Name, "base-categories")))
                    return true;


            if (Category == "SubCategory")
                if (sub_category.Contains(Collect.GetIdFromName(Name, "sub-categories")))
                    return true;


            if (Category == "Gender")
                if (gender.Contains(Collect.GetIdFromName(Name, "genders")))
                    return true;

            if (Category == "Size")
                if (size.Contains(Collect.GetIdFromName(Name, "sizes")))
                    return true;

            if (Category == "Color")
                if (color.Contains(Collect.GetIdFromName(Name, "clothe-colors")))
                    return true;

            if (Category == "State")
                if (clothe_condition.Contains(Collect.GetIdFromName(Name, "clothe-state")))
                    return true;

            return false;
        }

        public void AddCheckFields(List<string> list, string Category)
        {
            var Collect = Collections.Instance();

            if (Category == "Category")
                base_category = list;

            if (Category == "SubCategory" || Category == "sub-categories")
                sub_category = list;

            if (Category == "Gender")
                gender = list;

            if (Category == "Size")
                size = list;

            if (Category == "Color")
                color = list;

            if (Category == "State")
                clothe_condition = list;

        }

        public string JsonSearch()
        {
            Pagination pag = new Pagination();
            MetaDataSearch search = new MetaDataSearch();

            pag.ItemsPerPage = 100;
            pag.PageNumber = 1;

            search.base_category = base_category;
            search.brand = brand;
            search.clothe_condition = clothe_condition;
            search.color = color;
            search.gender = gender;
            search.sub_category = sub_category;
            search.size = size;
            search.Title = title;
            string json2 = JsonConvert.SerializeObject(search);

            Debug.WriteLine("LE JSON DE MON CUL est : " + json2);

            return "";
        }

        public void SaveCurrentSearch(string Name)
        {
            ;
        }

    }
}
