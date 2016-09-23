using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DBContext;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext();
            var User = db.Customers.FirstOrDefault();
            Console.Write(User.Name);
            Console.Read();
        }
    }
}
