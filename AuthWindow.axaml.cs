using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo2704.Context;
using Demo2704.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo2704;

public partial class AuthWindow : Window
{
    public User _user;
    public AuthWindow()
    {
        InitializeComponent();
        Load();
    }

    public AuthWindow(User user)
    {
        InitializeComponent();
        _user = user;
        if (user.Userrole != 1)
        {
            //AddProductButton.IsVisible = false;
            // ViewUsersButton.IsVisible = false;

        }
    }
     public void Load()
     {
        var dbUser25Context = new DbUser25Context();
        var list = dbUser25Context.Products.Include(x => x.Productmanufacturer).Include(x => x.Productcategory).ToList();

        OrderListBox.ItemsSource = list;
    }
    
    private void OrderListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {

    }
}




