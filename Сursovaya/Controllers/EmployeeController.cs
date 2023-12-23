using System.Linq;
using Сursovaya.Context;
using Сursovaya.Entities;

namespace Сursovaya.Controllers;

public class EmployeeController
{
    public static void PostEmployee(  string firstname, string surname, string midname ,string phonenumber,string login, string password,MyDbContext db)
    {
        Employee employee = new Employee();
        employee.Firstname = firstname;
        employee.Surname = surname;
        employee.Midname = midname;
        employee.PhoneNumber = phonenumber;
        employee.Login = login;
        employee.Password = password;
        db.Add(employee);
        db.SaveChanges();
        
    }
    
    public static void ChangeEmployee( int index, string firstname, string surname, string midname ,string phonenumber,string login, string password, MyDbContext db)
    {
        var client = db.Employees.First(x => x.IdEmployee == index);
        client.Firstname = firstname;
        client.Surname = surname;
        client.Midname = midname;
        client.PhoneNumber = phonenumber;
        client.Login = login;
        client.Password = password;
        db.Update(client);
        db.SaveChanges();
    }

    public static void DeleteEmployee(int index, MyDbContext db)
    {
        var buy = db.Employees.First(x => x.IdEmployee == index);
        db.Remove(buy);
        db.SaveChanges();
    }
}