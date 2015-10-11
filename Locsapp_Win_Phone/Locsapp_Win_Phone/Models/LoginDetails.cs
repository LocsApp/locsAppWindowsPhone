using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone.Models
{
    class SignUpDetails
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string password1 { get; set; }
        public string password2 { get; set; }
        public string birthday { get; set; }
        public string phone { get; set; }
        public string living_adress { get; set; }
        public string biling_adress { get; set; }
        public string logo_url { get; set; }
        public string is_active { get; set; }
    }

    class LoginDetails
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
