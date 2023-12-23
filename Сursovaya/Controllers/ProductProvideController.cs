using System;
using System.Linq;
using Сursovaya.Context;
using Сursovaya.Entities;

namespace Сursovaya.Controllers;

public class ProductProvideController
{
    public static void PostProductProvide(  int idProvide, int idProduct, int count ,decimal price,MyDbContext db)
    {
        Productsprovide newPb = new Productsprovide();
        newPb.IdProvide = idProvide;
        newPb.IdProduct = idProduct;
        newPb.Count = count;
        newPb.PriceForOne = price;
        newPb.Sum = Convert.ToDecimal(price * count);
        db.Add(newPb);
        db.SaveChanges();
    }
    
    public static void ChangeProductProvide(int idProvide, int idProduct,
        int count ,decimal price,MyDbContext db)
    {
        var client = db.Productsprovides.First(x => x.IdProvide == idProvide && x.IdProduct == idProduct);
        client.Count = count;
        client.PriceForOne = price;
        client.Sum = count * price;
        db.Update(client);
        db.SaveChanges();
    }

    public static void DeleteProductProvide(int indexProvide, int indexProduct, MyDbContext db)
    {
        var client = db.Productsprovides.First(x => x.IdProvide == indexProvide && x.IdProduct == indexProduct);
        db.Remove(client);
        db.SaveChanges();
    }
}