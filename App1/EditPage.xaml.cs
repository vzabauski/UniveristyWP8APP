using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

namespace UserDB
{
    
    public sealed partial class EditPage : Page
    {
        public EditPage()
        {
            this.InitializeComponent();
            //HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /*
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }
        */

        public long Id { get; set; }
        public User user = new User();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                long id = (long)e.Parameter;
                user = App.database.GetUser(id);
                if (user != null)
                {
                    loginBox.Text = user.Login;
                    passwordBox.Text = user.Pass;
                    updateButton.IsEnabled = true;
                }
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(loginBox.Text) && !String.IsNullOrEmpty(passwordBox.Text) && (((ComboBoxItem)ComboBox1.SelectedValue != null)))
            {
                user.Login = loginBox.Text;
                user.Pass = passwordBox.Text;
                user.Role = ((ComboBoxItem)ComboBox1.SelectedItem).Content.ToString();
                App.database.Update(user);
                MessageDialog msg = new MessageDialog("Succesfully updated");
                Frame.GoBack();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
