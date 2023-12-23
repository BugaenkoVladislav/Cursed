using System;
using System.Linq;
using Сursovaya.Context;
using Сursovaya.Entities;

namespace Сursovaya.Controllers;

public class ProvideController
{
    public static void PostProvide(DateOnly date, int  idEmployee , int  idProvider ,MyDbContext db)
    {
        Provide provide = new Provide();
        provide.Date = date;
        provide.IdEmployee = idEmployee;
        provide.IdProvider = idProvider;
        db.Add(provide);
        db.SaveChanges();
        
    }
    
    public static void ChangeProvide( int index, DateOnly date, int  idEmployee , int  idProvider ,MyDbContext db)
    {
        var buy = db.Provides.First(x => x.IdProvide == index);
        buy.Date = date;
        buy.IdEmployee = idEmployee;
        buy.IdProvider = idProvider;
        db.Update(buy);
        db.SaveChanges();
    }

    public static void DeleteProvide(int index, MyDbContext db)
    {
        var buy = db.Provides.First(x => x.IdProvide == index);
        db.Remove(buy);
        db.SaveChanges();
    }
}