﻿#pragma checksum "C:\Users\Tagzz\Desktop\Phone1\locsappwindowsphone\Locsapp_Win_Phone\Locsapp_Win_Phone\Views\Likes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6620488F9AA4AF408265A3CE416C64A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Locsapp_Win_Phone
{
    partial class Likes : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Show = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 2:
                {
                    this.Sign_up_Scroll = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.FavoriteSearch = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 42 "..\..\..\Views\Likes.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.FavoriteSearch).Tapped += this.FavoriteSearch_Tapped;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 51 "..\..\..\Views\Likes.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Button_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.FavoriteArticles = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 24 "..\..\..\Views\Likes.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.FavoriteArticles).Tapped += this.FavoriteArticles_Tapped;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 35 "..\..\..\Views\Likes.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Button_Click_2;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

