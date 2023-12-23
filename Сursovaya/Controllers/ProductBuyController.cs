using System;
using System.Linq;
using Сursovaya.Context;
using Сursovaya.Entities;

namespace Сursovaya.Controllers;

public class ProductBuyController
{
    public static void PostProductBuy(  int idBuy, int idProduct, int count ,decimal price,MyDbContext db)
    {
        Productsbuy newPb = new Productsbuy();
        newPb.IdBuy = idBuy;
        newPb.IdProduct = idProduct;
        newPb.Count = count;
        newPb.Price = price;
        newPb.Sum = Convert.ToDecimal(price * count);
        db.Add(newPb);
        db.SaveChanges();
    }
    
    public static void ChangeProductBuy(int idBuy, int idProduct,
        int count ,decimal price,MyDbContext db)
    {
        var client = db.Productsbuys.First(x => x.IdBuy == idBuy && x.IdProduct == idProduct);
        client.Count = count;
        client.Price = price;
        client.Sum = count * price;
        db.Update(client);
        db.SaveChanges();
    }

    public static void DeleteProductBuy(int indexBuy, int indexProduct, MyDbContext db)
    {
        var client = db.Productsbuys.First(x => x.IdBuy == indexBuy && x.IdProduct == indexProduct);
        db.Remove(client);
        db.SaveChanges();
    }
}