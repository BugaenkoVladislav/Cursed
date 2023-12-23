using System;
using System.Collections.Generic;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya.Forms;

public partial class ClientForm : Window
{
    MyDbContext db;
    public ClientForm()
    {
        
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
    }
    
    void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Client> InitDataGrid()
    {
        List<Client> list = new List<Client>();
        foreach (var i in db.Clients)
        {
            list.Add(new Client()
            {
                IdClient = i.IdClient,
                Firstname = i.Firstname,
                Midname = i.Midname,
                Surname = i.Surname,
                PhoneNumber = i.PhoneNumber
            }); 
        }
        return list;
    }
    private void Add_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ClientController.PostClient(firstname.Text, surname.Text, midname.Text, phonenumber.Text, db);
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
            ClientController.ChangeClient(Convert.ToInt32(idClient.Text),firstname.Text,surname.Text,midname.Text,phonenumber.Text,db);
            GridInit();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не верно указаны данные ");
        }
        
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ClientController.DeleteClent(Convert.ToInt32(idClient.Text),db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Нe правильно указан ID ");
        }
        
    }
    
}
public  class Client
{
    public int IdClient { get; set; }

    public string Firstname { get; set; } = null!;

    public string Midname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
    
}