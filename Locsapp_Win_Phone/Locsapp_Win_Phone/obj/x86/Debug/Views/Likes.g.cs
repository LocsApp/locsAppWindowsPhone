﻿#pragma checksum "C:\Users\Tagzz\Desktop\Phone1\locsappwindowsphone\Locsapp_Win_Phone\Locsapp_Win_Phone\Views\Likes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "88CD6AD38995262E6A1179D7D265EC2F"
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
                    this.FavoriteSearch = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 20 "..\..\..\Views\Likes.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.FavoriteSearch).Tapped += this.FavoriteSearch_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\Views\Likes.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Button_Click;
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

