using System.Collections.Generic;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Entities;
using Сursovaya.Forms;

namespace Сursovaya;

public partial class Tables : Window
{
    private MyDbContext db;
    public Tables()
    {
        InitializeComponent();
        db = new MyDbContext();
    }

    private void Products_OnClick(object sender, RoutedEventArgs e)
    {
        ProductForm template = new ProductForm();
        template.Show();
    }

    private void Employees_OnClick(object sender, RoutedEventArgs e)
    {
        EmployeeForm template = new EmployeeForm();
        template.Show();
    }

    private void Providers_OnClick(object sender, RoutedEventArgs e)
    {
       ProviderForm template = new ProviderForm();
        template.Show();
    }

    private void Buys_OnClick(object sender, RoutedEventArgs e)
    {
        BuyForm template = new BuyForm();
        template.Show();
    }

    private void Clients_OnClick(object sender, RoutedEventArgs e)
    {
        ClientForm template = new ClientForm();
        template.Show();
    }

    private void Provides_OnClick(object sender, RoutedEventArgs e)
    {
        ProvideForm template = new ProvideForm ();
        template.Show();
    }
}