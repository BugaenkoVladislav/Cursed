using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya.ReportForms;

public partial class ProductBuyForm : Window
{
    private MyDbContext db;
    public ProductBuyForm()
    {
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
    }
    void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Productsbuy> InitDataGrid()
    {
        List<Productsbuy> list = new List<Productsbuy>();
        using (var context = new MyDbContext())
        {
            foreach (var i in context.Productsbuys)
            {
               
                list.Add(new Productsbuy()
                {
                    IdBuy = i.IdBuy,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count= i.Count,
                    Price= i.Price,
                    Sum = i.Price * i.Count
                }); 
            }
        }
        return list;
    }
    public  List<Productsbuy> InitFilter(int? idproduct, int? buy)
    {
        List<Productsbuy> list = new List<Productsbuy>();
        if (idproduct != null && buy != null)
        {
            foreach (var i in db.Productsbuys.Where(x=> x.IdProduct == idproduct && x.IdBuy==buy).ToList())
            {
                list.Add(new Productsbuy()
                {
                    IdBuy = i.IdBuy,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count= i.Count,
                    Price= i.Price,
                    Sum = i.Price * i.Count
                }); 
            }
        }
        else if (buy != null)
        {
            foreach (var i in db.Productsbuys.Where(x=>  x.IdBuy==buy).ToList())
            {
                list.Add(new Productsbuy()
                {
                    IdBuy = i.IdBuy,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count= i.Count,
                    Price= i.Price,
                    Sum = i.Price * i.Count
                }); 
            }
        }
        else if(idproduct!=null)
        {
            foreach (var i in db.Productsbuys.Where(x=> x.IdProduct == idproduct).ToList())
            {
                list.Add(new Productsbuy()
                {
                    IdBuy = i.IdBuy,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count= i.Count,
                    Price= i.Price,
                    Sum = i.Price * i.Count
                }); 
            }
            
        }
        return list;
    }
    
   

    private void Filter_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            int? numProduct = db.Products.FirstOrDefault(x => x.Name == idProduct.Text)?.IdProduct;
            bool m = Int32.TryParse(idBuy.Text, out int buy);
            if (numProduct != null || m == true) 
            {
                
                    int? numBuy = db.Buys.FirstOrDefault(x => x.IdBuy == buy)?.IdBuy;
                    MyDataGrid.ItemsSource = InitFilter(numProduct, numBuy);
            }
            else
            {
                MessageBox.Show("Укажите хотя бы 1 ID");
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Неправильно задан ID ");
        }
    }


}

public  class Productsbuy
{
    public int IdBuy { get; set; } 

    public string IdProduct { get; set; }

    public int Count { get; set; }

    public decimal Price { get; set; }

    public decimal Sum { get; set; }
}