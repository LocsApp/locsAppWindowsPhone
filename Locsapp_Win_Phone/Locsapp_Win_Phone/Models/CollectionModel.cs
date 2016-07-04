using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locsapp_Win_Phone.Models
{
    //Gender
    public class Gender
    {
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class RootGendre
    {
        public List<Gender> genders { get; set; }
    }

    //SubCategory
    public class SubCategory
    {
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class RootSubCategory
    {
        public List<SubCategory> sub_categories { get; set; }
    }

    //BaseCategory
    public class BaseCategory
    {
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class RootBaseCategory
    {
        public List<BaseCategory> Base_categories { get; set; }
    }


    //Sizes
    public class Sizes
    {
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class RootSizes
    {
        public List<Sizes> Sizes { get; set; }
    }

    //ClotheColors
    public class ClotheColor
    {
        public string _id { get; set; }
        public string hex_code { get; set; }
        public string name { get; set; }
    }

    public class RootClothColors
    {
        public List<ClotheColor> clothe_colors { get; set; }
    }

    //ClothStates
    public class ClothStates
    {
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class RootClothStates
    {
        public List<ClothStates> ClothStates { get; set; }
    }

    //PayementMethods
    public class PaymentMethod
    {
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class RootPaymentMethod
    {
        public List<PaymentMethod> payment_methods { get; set; }
    }
}
