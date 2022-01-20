﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TourGuide.service;

namespace TourGuideUI
{
    /// <summary>
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserService userService = new UserService();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void passwordConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(username.Text.Length > 0
                && passwordConfirm.Password.Length > 0
                && password.Password == passwordConfirm.Password)
            {
                userSubmit.Background = new SolidColorBrush(Color.FromRgb(0, 98, 255));
            } 
        }

        private void userSubmit_Click(object sender, RoutedEventArgs e)
        {
            userService.AddNewUser(username.Text, password.Password);

            LoginWindow loginScreen = new LoginWindow();
            loginScreen.Show();
            this.Close();
        }
    }
}