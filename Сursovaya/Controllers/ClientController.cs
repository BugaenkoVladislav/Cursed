using System;
using System.Linq;
using Сursovaya.Context;

namespace Сursovaya.Controllers;

public class ClientController
{
    public static void PostClient(  string firstname, string surname, string midname ,string phonenumber,MyDbContext db)
    {
        db.Add(new Entities.Client()
        {
            Firstname = firstname,
            Surname = surname,
            Midname = midname,
            PhoneNumber = phonenumber
        });
        db.SaveChanges();
        
    }
    
    public static void ChangeClient( int index, string firstname, string surname, string midname ,string phonenumber, MyDbContext db)
    {
        var client = db.Clients.First(x => x.IdClient == index);
        client.Firstname = firstname;
        client.Surname = surname;
        client.Midname = midname;
        client.PhoneNumber = phonenumber;
        db.Update(client);
        db.SaveChanges();
    }

    public static void DeleteClent(int index, MyDbContext db)
    {
        var buy = db.Clients.First(x => x.IdClient == index);
        db.Remove(buy);
        db.SaveChanges();
    }
}