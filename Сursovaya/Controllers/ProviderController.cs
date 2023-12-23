using System.Linq;
using Сursovaya.Context;

namespace Сursovaya.Controllers;

public class ProviderController
{
    public static void PostProvider(string name , string  phone,MyDbContext db)
    {
        db.Add(new Entities.Provider()
        {
            Name = name,
            PhoneNumber = phone
        });
        db.SaveChanges();
        
    }
    
    public static void ChangeProvider( int index, string name, string phone ,MyDbContext db)
    {
        var buy = db.Providers.First(x => x.IdProvider == index);
        buy.Name = name;
        buy.PhoneNumber = phone;
        db.Update(buy);
        db.SaveChanges();
    }

    public static void DeleteProvider(int index, MyDbContext db)
    {
        var buy = db.Providers.First(x => x.IdProvider == index);
        db.Remove(buy);
        db.SaveChanges();
    }
}