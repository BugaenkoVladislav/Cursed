using System;
using System.Collections.Generic;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya.Forms;

public partial class BuyForm : Window
{
    private MyDbContext db;
    public BuyForm()
    {
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
    }

    void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Buy> InitDataGrid()
    {
        List<Buy> list = new List<Buy>();
        foreach (var i in db.Buys)
        {
           list.Add(new Buy()
           {
               IdBuy = i.IdBuy,
               Date = i.Date,
               IdClient = i.IdClient,
               IdEmployee = i.IdEmployee
           }); 
        }
        return list;
    }

    private void Add_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            BuyController.PostBuy(DateOnly.FromDateTime(Picker.SelectedDate.Value), Convert.ToInt32(idClient.Text), Convert.ToInt32(idEmployee.Text), db);
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

            BuyController.ChangeBuy(Convert.ToInt32(idBuy.Text),
                DateOnly.FromDateTime(Picker.SelectedDate.Value),
                Convert.ToInt32(idClient.Text), Convert.ToInt32(idEmployee.Text), db);
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
            BuyController.DeleteBuy(Convert.ToInt32(idBuy.Text), db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Не правильно указан ID");
        }
            
        
        
    }
}

public class Buy
{
    public int IdBuy { get; set; }

    public DateOnly Date { get; set; }

    public int IdClient { get; set; }

    public int IdEmployee { get; set; }
}