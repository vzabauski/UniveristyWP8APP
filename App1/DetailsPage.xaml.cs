﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace UserDB
{
    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        public long Id { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                long id = (long)e.Parameter;
                User u = App.database.GetUser(id);
                if (u != null)
                {
                    loginBlock.Text = u.Login;
                    passwordBlock.Text = u.Pass;
                    roleBlock.Text = u.Role;
                    deleteButton.IsEnabled = true;
                    updateButton.IsEnabled = true;
                    Id = id;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "deleteButton")
                App.database.Delete(Id);

            /*if (button.Name == "updateButton")
            {
                Frame.Navigate(typeof(EditPage), Id);
            }
            */
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditPage), Id);
        }
    }
}
