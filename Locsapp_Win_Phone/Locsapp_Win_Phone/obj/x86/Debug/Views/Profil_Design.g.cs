﻿#pragma checksum "C:\Users\Tagzz\Desktop\locsAppWindowsPhone\Locsapp_Win_Phone\Locsapp_Win_Phone\Views\Profil_Design.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F1FBB29EFF87D51AEDE33DCECBAC0CEB"
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
    partial class Profil_Design : 
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
                    #line 13 "..\..\..\Views\Profil_Design.xaml"
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
                    this.HamburgerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4:
                {
                    this.MenuButton1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\Views\Profil_Design.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.MenuButton1).Click += this.Logout;
                    #line default
                }
                break;
            case 5:
                {
                    this.Sign_up_Scroll = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 6:
                {
                    this.EditProfile_Man = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 7:
                {
                    this.EditProfile_Woman = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 8:
                {
                    this.EditProfile_Name = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9:
                {
                    this.EditProfile_FirstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10:
                {
                    this.EditProfile_Phone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11:
                {
                    this.EditProfile_Birthday = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 12:
                {
                    this.EditProfile_Email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13:
                {
                    this.EditProfile_OldPass = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 14:
                {
                    this.EditProfile_NewPass1 = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 15:
                {
                    this.EditProfile_NewPass2 = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 16:
                {
                    this.EditProfile_Send = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 116 "..\..\..\Views\Profil_Design.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.EditProfile_Send).Click += this.Send_Data;
                    #line default
                }
                break;
            case 17:
                {
                    this.View_Username = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18:
                {
                    this.View_Sex = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19:
                {
                    this.View_Birthday = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20:
                {
                    this.View_Map = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 21:
                {
                    this.View_Subscribed = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

