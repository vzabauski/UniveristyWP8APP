using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;


namespace UserDB
{
    public sealed partial class LoginPage : Page
    {
        public string real_password="password";
        public string real_login = "login";
        public LoginPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (real_password == password_textbox.Password && real_login == login_textbox.Text)
            {
                string MessageString = String.Format("You have signed in as '{0}'", login_textbox.Text);
                MessageDialog msg = new MessageDialog(MessageString);
                await msg.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                MessageDialog msg = new MessageDialog("Wrong login or password");
                msg.Commands.Add(new UICommand("Try again"));
                msg.Commands.Add(new UICommand("Exit"));
                var result = await msg.ShowAsync();
                if (result.Label == "Exit")
                {
                    Application.Current.Exit();
                }

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
