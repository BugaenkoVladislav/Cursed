using System;
using System.Linq;
using Сursovaya.Context;

namespace Сursovaya.Controllers;

public class ProductController
{
    public static void PostProduct(string name , string  desc,MyDbContext db)
    {
        db.Add(new Entities.Product()
        {
            Name = name,
            Description = desc
        });
        db.SaveChanges();
        
    }
    
    public static void ChangeProduct( int index, string name, string desc ,MyDbContext db)
    {
        var buy = db.Products.First(x => x.IdProduct == index);
        buy.Name = name;
        buy.Description = desc;
        db.Update(buy);
        db.SaveChanges();
    }

    public static void DeleteProduct(int index, MyDbContext db)
    {
        var buy = db.Products.First(x => x.IdProduct == index);
        db.Remove(buy);
        db.SaveChanges();
    }
}