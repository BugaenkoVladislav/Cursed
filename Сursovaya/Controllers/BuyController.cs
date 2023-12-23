using System;
using System.Linq;
using System.Windows.Controls;
using Сursovaya.Context;
using Сursovaya.Forms;

namespace Сursovaya.Controllers;

public class BuyController
{
    public static void PostBuy( DateOnly date, int idClient, int idEmployee,MyDbContext db)
    {
        
        db.Add(new Entities.Buy()
        {
            Date = date,
            IdClient = idClient,
            IdEmployee = idEmployee
        });
        db.SaveChanges();
        
    }
    
    public static void ChangeBuy( int index, DateOnly date, int idClient, int idEmployee,MyDbContext db)
    {
        var buy = db.Buys.First(x => x.IdBuy == index);
        buy.Date = date;
        buy.IdClient = idClient;
        buy.IdEmployee = idEmployee;
        db.Update(buy);
        db.SaveChanges();
    }

    public static void DeleteBuy(int index, MyDbContext db)
    {
        var buy = db.Buys.First(x => x.IdBuy == index);
        db.Remove(buy);
        db.SaveChanges();
    }
}