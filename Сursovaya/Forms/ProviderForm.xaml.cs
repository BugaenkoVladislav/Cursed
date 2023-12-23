using System;
using System.Collections.Generic;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya.Forms;

public partial class ProviderForm : Window
{
    private MyDbContext db;
    public ProviderForm()
    {
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
    }

    void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Provider> InitDataGrid()
    {
        List<Provider> list = new List<Provider>();
        foreach (var i in db.Providers)
        {
            list.Add(new Provider()
            {
                IdProvider = i.IdProvider,
                Name = i.Name,
                PhoneNumber = i.PhoneNumber
            }); 
        }
        return list;
    }

    private void Add_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProviderController.PostProvider(name.Text, phone.Text, db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Не верно указаны данные");
        }
        
    }

    private void Update_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProviderController.ChangeProvider(Convert.ToInt32(idProvider.Text),name.Text,phone.Text,db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Не верно указанны данные");
        }
        
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProviderController.DeleteProvider(Convert.ToInt32(idProvider.Text),db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Неправильно указан ID");
        }
    }
}
public class Provider
{
    public int IdProvider { get; set; }

    public string Name { get; set; } 

    public string PhoneNumber { get; set; }
}