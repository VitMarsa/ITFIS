using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITFIS
{
    class Program
    {
        static void Main(string[] args)
        {
            ITFISDBEntities db = new ITFISDBEntities();            
            User nu = new User();
            nu.Password = "1*Heslo";
            nu.Name = "Petr";
            nu.Surname = "Krejčí";
            nu.RoleId = 3;
            db.Users.Add(nu);
            db.SaveChanges();

            foreach (User u in db.Users)
            {                
                Role role = db.Roles.FirstOrDefault(r => r.Id == u.RoleId);
                Console.WriteLine("{0}; {1}; {2}", u.Name, u.Surname, role.Title);
            }

            foreach (Role r in db.Roles)
            {
                Console.WriteLine("{0}", r.Title);
            }
            Console.ReadKey();
        }
    }
}
