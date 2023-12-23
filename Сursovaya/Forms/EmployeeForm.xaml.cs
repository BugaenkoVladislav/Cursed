using System;
using System.Collections.Generic;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Controllers;
using Сursovaya.Entities;

namespace Сursovaya.Forms;

public partial class EmployeeForm : Window
{
    private MyDbContext db;
    public EmployeeForm()
    {
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
    }

    void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Employee> InitDataGrid()
    {
        List<Employee> list = new List<Employee>();
        foreach (var i in db.Employees)
        {
            list.Add(new Employee()
            {
                IdEmployee = i.IdEmployee,
                Firstname = i.Firstname,
                Midname = i.Midname,
                Surname = i.Surname,
                PhoneNumber = i.PhoneNumber,
                Login = i.Login,
                Password = i.Password
            }); 
        }
        return list;
    }

    private void Add_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            EmployeeController.PostEmployee(firstname.Text, surname.Text, midname.Text, phonenumber.Text, login.Text, password.Text, db);
            GridInit();
        }
        catch(Exception)
        {
            MessageBox.Show("Не верно указаны данные");
        }
        
    }

    private void Update_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            EmployeeController.ChangeEmployee(Convert.ToInt32(idEmployee.Text), firstname.Text, surname.Text, midname.Text,
                phonenumber.Text, login.Text, password.Text, db);
            
            GridInit();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не верно указанны данные ");
        }
    }
    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            EmployeeController.DeleteEmployee(Convert.ToInt32(idEmployee.Text),db);
            GridInit();
        }
        catch (Exception)
        {
            MessageBox.Show("Неправильно указан ID");
        }
        
    }
}

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string Firstname { get; set; } 

    public string Midname { get; set; }

    public string Surname { get; set; } 

    public string PhoneNumber { get; set; } 

    public string Login { get; set; } 

    public string Password { get; set; } 
}