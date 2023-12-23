using System;
using System.Collections.Generic;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya.Forms;

public partial class ProvideForm : Window
{
    private MyDbContext db;
    public ProvideForm()
    {
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
        
    }
    void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Provide> InitDataGrid()
    {
        List<Provide> list = new List<Provide>();
        foreach (var i in db.Provides)
        {
            list.Add(new Provide()
            {
                IdProvide = i.IdProvide,
                Date = i.Date,
                IdEmployee = i.IdEmployee,
                IdProvider = i.IdProvider
            }); 
        }
        return list;
    }

    private void Add_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProvideController.PostProvide(DateOnly.FromDateTime(date.SelectedDate.Value),
            Convert.ToInt32(idEmployee.Text), Convert.ToInt32(idProvider.Text), db);
            GridInit();
        }
        catch(Exception ex)
        {
            MessageBox.Show("Не верно указаны данные");
        }
        
    }

    private void Update_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProvideController.ChangeProvide(Convert.ToInt32(idProvide.Text),DateOnly.FromDateTime(date.SelectedDate.Value),
                Convert.ToInt32(idEmployee.Text),Convert.ToInt32(idProvider.Text),db);
            GridInit();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не верно указаны данные");
        }
         
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ProvideController.DeleteProvide(Convert.ToInt32(idProvide.Text),db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Не правильно указан ID");
        }
    }
}

public class Provide
{
    public int IdProvide { get; set; }

    public DateOnly Date { get; set; }

    public int IdProvider { get; set; }

    public int IdEmployee { get; set; }
}

