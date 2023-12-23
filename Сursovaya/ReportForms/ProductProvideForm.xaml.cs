using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Сursovaya.Context;
using Сursovaya.Controllers;

namespace Сursovaya.ReportForms;

public partial class ProductProvideForm : Window
{
    private MyDbContext db;
    public ProductProvideForm()
    {
        InitializeComponent();
        db = new MyDbContext();
        GridInit();
    }
        void GridInit()
    {
        MyDataGrid.ItemsSource = InitDataGrid();
    }

    public  List<Productsprovide> InitDataGrid()
    {
        List<Productsprovide> list = new List<Productsprovide>();
        using (var context = new MyDbContext())
        {
            foreach (var i in context.Productsprovides)
            {
                list.Add(new Productsprovide()
                {
                    IdProvide = i.IdProvide,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count = i.Count,
                    PriceForOne = i.PriceForOne,
                    Sum = i.PriceForOne * i.Count
                }); 
            }
        }
        return list;
    }
    public  List<Productsprovide> InitFilter(int? idprovide, int? idproduct)
    {
        List<Productsprovide> list = new List<Productsprovide>();
        if (idproduct != null && idprovide != null)
        {
            foreach (var i in db.Productsprovides.Where(x=>x.IdProvide==idprovide && x.IdProduct == idproduct).ToList())
            {
                list.Add(new Productsprovide()
                {
                    IdProvide = i.IdProvide,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count= i.Count,
                    PriceForOne= i.PriceForOne,
                    Sum = i.PriceForOne * i.Count
                }); 
            }
        }
        else if(idproduct!=null)
        {
            foreach (var i in db.Productsprovides.Where(x=>x.IdProduct == idproduct).ToList())
            {
                list.Add(new Productsprovide()
                {
                    IdProvide = i.IdProvide,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count= i.Count,
                    PriceForOne= i.PriceForOne,
                    Sum = i.PriceForOne * i.Count
                }); 
            }
        }
        else if (idprovide != null)
        {
            foreach (var i in db.Productsprovides.Where(x=>x.IdProvide==idprovide).ToList())
            {
                list.Add(new Productsprovide()
                {
                    IdProvide = i.IdProvide,
                    IdProduct= db.Products.First(x=>x.IdProduct == i.IdProduct).Name,
                    Count = i.Count,
                    PriceForOne = i.PriceForOne,
                    Sum = i.PriceForOne * i.Count
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
            bool m = Int32.TryParse(idProvide.Text, out int buy);
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

public partial class Productsprovide
{
    public int IdProvide { get; set; }

    public string IdProduct { get; set; }

    public int Count { get; set; }

    public decimal PriceForOne { get; set; }

    public decimal Sum { get; set; }
}