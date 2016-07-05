using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone.ViewModels
{
    class CurrentSearch
    {
        private static CurrentSearch _instance = null;
        private List<string> base_category = new List<string>();
        private List<string> sub_category = new List<string>();
        private List<string> gender = new List<string>();
        private List<string> brand = new List<string>();
        private List<string> clothe_condition = new List<string>();
        private List<string> color = new List<string>();
        private List<string> size = new List<string>();

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
            return false;
        }

        public string JsonSearch()
        {
            return "";
        }

        public void SaveCurrentSearch(string Name)
        {
            ;
        }

    }
}
