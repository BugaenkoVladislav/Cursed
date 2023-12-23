using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using Сursovaya.Context;
using Сursovaya.Entities;

//using Сursovaya.Context;

namespace Сursovaya.Controllers;

public class UserController
{
    public UserController()
    {
    }

    public static bool SignIn(string login, string password, MyDbContext db)
    {
        if (db.Employees.FirstOrDefault(x => x.Password == password && x.Login == login) == null)
        {
            return false;
        }
        return true;
    }
}