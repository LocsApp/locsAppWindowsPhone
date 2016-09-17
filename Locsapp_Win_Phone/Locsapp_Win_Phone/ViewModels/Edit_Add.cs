using Locsapp_Win_Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone.ViewModels
{
    class Edit_Add
    {

        public int index = 0;
        public string Type_Edit = "";
        public List<List<string>> Add = new List<List<string>>();
        private static Edit_Add _instance = null;
        public UserInfos data = new UserInfos();

        private Edit_Add()
        {
        }

        public static Edit_Add Instance()
        {
            if (_instance == null)
                _instance = new Edit_Add();
            return _instance;
        }

    }
}
