using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo2704.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Demo2704;

public partial class GuestWindow : Window
{
    public GuestWindow()
    {
        InitializeComponent();
        Load();
    }

    public void Load()
    {
        var dbUser25Context = new DbUser25Context();
        var list = dbUser25Context.Products.Include(x => x.Productmanufacturer).Include(x => x.Productcategory).ToList();

        OrderListBox1.ItemsSource = list;
    }

    private void OrderListBox1_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {

    }
}