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

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace App1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public string real_password="password";
        public string real_login = "login";
        public BlankPage1()
        {
            this.InitializeComponent();
            
        }
        Window.Current.SizeChanged += Current_SizeChanged;

            void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            // Get the new view state
            // Add: using Windows.UI.ViewManagement;
            string CurrentViewState = ApplicationView.GetForCurrentView().Orientation.ToString();
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = login_textbox.Text;
            string password = password_textbox.Text;
            if (password == real_password && login == real_login)
            {
                MessageDialog msg = new MessageDialog("Correct!");
                await msg.ShowAsync();
                Frame.Navigate(typeof(PivotPage));
            }
            else
            {
                MessageDialog msg = new MessageDialog("Wrong login and/or password!");
                await msg.ShowAsync();
                Application.Current.Exit();
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
