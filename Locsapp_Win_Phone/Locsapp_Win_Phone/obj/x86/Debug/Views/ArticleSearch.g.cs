﻿#pragma checksum "C:\Users\Tagzz\Desktop\Phone1\locsappwindowsphone\Locsapp_Win_Phone\Locsapp_Win_Phone\Views\ArticleSearch.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CFE2A6F989D87593BB32FA2A204BA082"
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
    partial class ArticleSearch : 
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
                    #line 13 "..\..\..\Views\ArticleSearch.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Show).Click += this.HamburgerButton_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.SplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 83 "..\..\..\Views\ArticleSearch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Button_Click;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 84 "..\..\..\Views\ArticleSearch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 5:
                {
                    this.MenuButton3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 45 "..\..\..\Views\ArticleSearch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.MenuButton3).Click += this.MenuButton3_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.MenuButton2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 40 "..\..\..\Views\ArticleSearch.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.MenuButton2).Click += this.MenuButton2_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.HamburgerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 8:
                {
                    this.MyList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 52 "..\..\..\Views\ArticleSearch.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MyList).Tapped += this.MyList_Tapped;
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

