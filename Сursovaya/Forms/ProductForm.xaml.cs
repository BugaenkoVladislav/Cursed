using System;
using System.Collections.Generic;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya.Forms;

public partial class ProductForm : Window
{
    private MyDbContext db;
    public ProductForm()
    {
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
    }
    void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Product> InitDataGrid()
    {
        List<Product> list = new List<Product>();
        foreach (var i in db.Products)
        {
            list.Add(new Product()
            {
                IdProduct = i.IdProduct,
                Name = i.Name,
                Description = i.Description
            }); 
        }
        return list;
    }

    private void Add_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProductController.PostProduct(name.Text, description.Text, db);
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
            ProductController.ChangeProduct(Convert.ToInt32(idBuy.Text),name.Text,description.Text,db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Не верно указаны данные");
        }
        
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProductController.DeleteProduct(Convert.ToInt32(idBuy.Text), db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Не правильно указан ID");
        }
        
    }
}

public class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } 

    public string Description { get; set; } 
}