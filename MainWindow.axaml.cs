using Avalonia.Controls;
using Avalonia.Interactivity;
using Demo2704.Context;
using MsBox.Avalonia;
using Demo2704.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Demo2704
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AuthButton_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                var con = new DbUser25Context();
                var user = con.Users.Include(x => x.UserroleNavigation).Where(x => x.Userlogin == LoginBox.Text && x.Userpassword == PasswordBox.Text).First();
                if (user != null)
                {
                   
                    var authWindow = new AuthWindow(user);
                    authWindow.Show();
                    this.Close();
                }
                else
                {
                    var box = MessageBoxManager.GetMessageBoxStandard("Error", "Неверный Логин или пароль", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
                    
                }
            }
            catch (Exception ex)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error", "Неверный Логин или пароль", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
            }
        }
        private void GuestButton_Click(object? sender, RoutedEventArgs e)
        {
            var guestWindow = new GuestWindow();
            guestWindow.Show();
            this.Close();
        }
    }
}