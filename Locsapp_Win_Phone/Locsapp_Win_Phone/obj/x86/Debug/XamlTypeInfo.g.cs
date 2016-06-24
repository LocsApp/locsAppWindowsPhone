﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Locsapp_Win_Phone
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[15];
            _typeNameTable[0] = "Locsapp_Win_Phone.AddAddress";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[3] = "Locsapp_Win_Phone.Article";
            _typeNameTable[4] = "Locsapp_Win_Phone.ArticleSearch";
            _typeNameTable[5] = "Locsapp_Win_Phone.Errorview";
            _typeNameTable[6] = "Locsapp_Win_Phone.FilterSearch";
            _typeNameTable[7] = "Locsapp_Win_Phone.HistoryArticle";
            _typeNameTable[8] = "Locsapp_Win_Phone.MainPage";
            _typeNameTable[9] = "Locsapp_Win_Phone.Profile";
            _typeNameTable[10] = "String";
            _typeNameTable[11] = "Locsapp_Win_Phone.ProfileData";
            _typeNameTable[12] = "Locsapp_Win_Phone.ProfilDesign";
            _typeNameTable[13] = "Locsapp_Win_Phone.SearchList";
            _typeNameTable[14] = "Locsapp_Win_Phone.SignUpPage";

            _typeTable = new global::System.Type[15];
            _typeTable[0] = typeof(global::Locsapp_Win_Phone.AddAddress);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[2] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[3] = typeof(global::Locsapp_Win_Phone.Article);
            _typeTable[4] = typeof(global::Locsapp_Win_Phone.ArticleSearch);
            _typeTable[5] = typeof(global::Locsapp_Win_Phone.Errorview);
            _typeTable[6] = typeof(global::Locsapp_Win_Phone.FilterSearch);
            _typeTable[7] = typeof(global::Locsapp_Win_Phone.HistoryArticle);
            _typeTable[8] = typeof(global::Locsapp_Win_Phone.MainPage);
            _typeTable[9] = typeof(global::Locsapp_Win_Phone.Profile);
            _typeTable[10] = typeof(global::System.String);
            _typeTable[11] = typeof(global::Locsapp_Win_Phone.ProfileData);
            _typeTable[12] = typeof(global::Locsapp_Win_Phone.ProfilDesign);
            _typeTable[13] = typeof(global::Locsapp_Win_Phone.SearchList);
            _typeTable[14] = typeof(global::Locsapp_Win_Phone.SignUpPage);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_AddAddress() { return new global::Locsapp_Win_Phone.AddAddress(); }
        private object Activate_3_Article() { return new global::Locsapp_Win_Phone.Article(); }
        private object Activate_4_ArticleSearch() { return new global::Locsapp_Win_Phone.ArticleSearch(); }
        private object Activate_5_Errorview() { return new global::Locsapp_Win_Phone.Errorview(); }
        private object Activate_6_FilterSearch() { return new global::Locsapp_Win_Phone.FilterSearch(); }
        private object Activate_7_HistoryArticle() { return new global::Locsapp_Win_Phone.HistoryArticle(); }
        private object Activate_8_MainPage() { return new global::Locsapp_Win_Phone.MainPage(); }
        private object Activate_9_Profile() { return new global::Locsapp_Win_Phone.Profile(); }
        private object Activate_11_ProfileData() { return new global::Locsapp_Win_Phone.ProfileData(); }
        private object Activate_12_ProfilDesign() { return new global::Locsapp_Win_Phone.ProfilDesign(); }
        private object Activate_13_SearchList() { return new global::Locsapp_Win_Phone.SearchList(); }
        private object Activate_14_SignUpPage() { return new global::Locsapp_Win_Phone.SignUpPage(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  Locsapp_Win_Phone.AddAddress
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_0_AddAddress;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  Locsapp_Win_Phone.Article
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_3_Article;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 4:   //  Locsapp_Win_Phone.ArticleSearch
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_4_ArticleSearch;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 5:   //  Locsapp_Win_Phone.Errorview
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_5_Errorview;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 6:   //  Locsapp_Win_Phone.FilterSearch
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_6_FilterSearch;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 7:   //  Locsapp_Win_Phone.HistoryArticle
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_7_HistoryArticle;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  Locsapp_Win_Phone.MainPage
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_8_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 9:   //  Locsapp_Win_Phone.Profile
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_9_Profile;
                userType.AddMemberName("Key");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 10:   //  String
                xamlType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 11:   //  Locsapp_Win_Phone.ProfileData
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_11_ProfileData;
                userType.AddMemberName("Key");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 12:   //  Locsapp_Win_Phone.ProfilDesign
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_12_ProfilDesign;
                userType.AddMemberName("Key");
                userType.AddMemberName("Id");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 13:   //  Locsapp_Win_Phone.SearchList
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_13_SearchList;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 14:   //  Locsapp_Win_Phone.SignUpPage
                userType = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_14_SignUpPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_Profile_Key(object instance)
        {
            var that = (global::Locsapp_Win_Phone.Profile)instance;
            return that.Key;
        }
        private void set_0_Profile_Key(object instance, object Value)
        {
            var that = (global::Locsapp_Win_Phone.Profile)instance;
            that.Key = (global::System.String)Value;
        }
        private object get_1_ProfileData_Key(object instance)
        {
            var that = (global::Locsapp_Win_Phone.ProfileData)instance;
            return that.Key;
        }
        private void set_1_ProfileData_Key(object instance, object Value)
        {
            var that = (global::Locsapp_Win_Phone.ProfileData)instance;
            that.Key = (global::System.String)Value;
        }
        private object get_2_ProfilDesign_Key(object instance)
        {
            var that = (global::Locsapp_Win_Phone.ProfilDesign)instance;
            return that.Key;
        }
        private void set_2_ProfilDesign_Key(object instance, object Value)
        {
            var that = (global::Locsapp_Win_Phone.ProfilDesign)instance;
            that.Key = (global::System.String)Value;
        }
        private object get_3_ProfilDesign_Id(object instance)
        {
            var that = (global::Locsapp_Win_Phone.ProfilDesign)instance;
            return that.Id;
        }
        private void set_3_ProfilDesign_Id(object instance, object Value)
        {
            var that = (global::Locsapp_Win_Phone.ProfilDesign)instance;
            that.Id = (global::System.String)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlMember xamlMember = null;
            global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "Locsapp_Win_Phone.Profile.Key":
                userType = (global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Locsapp_Win_Phone.Profile");
                xamlMember = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlMember(this, "Key", "String");
                xamlMember.Getter = get_0_Profile_Key;
                xamlMember.Setter = set_0_Profile_Key;
                break;
            case "Locsapp_Win_Phone.ProfileData.Key":
                userType = (global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Locsapp_Win_Phone.ProfileData");
                xamlMember = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlMember(this, "Key", "String");
                xamlMember.Getter = get_1_ProfileData_Key;
                xamlMember.Setter = set_1_ProfileData_Key;
                break;
            case "Locsapp_Win_Phone.ProfilDesign.Key":
                userType = (global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Locsapp_Win_Phone.ProfilDesign");
                xamlMember = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlMember(this, "Key", "String");
                xamlMember.Getter = get_2_ProfilDesign_Key;
                xamlMember.Setter = set_2_ProfilDesign_Key;
                break;
            case "Locsapp_Win_Phone.ProfilDesign.Id":
                userType = (global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Locsapp_Win_Phone.ProfilDesign");
                xamlMember = new global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlMember(this, "Id", "String");
                xamlMember.Getter = get_3_ProfilDesign_Id;
                xamlMember.Setter = set_3_ProfilDesign_Id;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlSystemBaseType
    {
        global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::Locsapp_Win_Phone.Locsapp_Win_Phone_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

