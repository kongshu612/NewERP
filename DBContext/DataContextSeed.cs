using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace DBContext
{
    public class DataContextSeed
    {
        private readonly DataContext _ct;
        public DataContextSeed(DataContext ct)
        {
            _ct = ct;
        }
        public void Seed()
        {
            _ct.Users.Add(new User() { UserName = "admin", Password = "123", IsAdmin = true });
            _ct.SaveChanges();

            Product Product1 = new Product() { Name = "Product1", Size = 100 };
            Product Product2 = new Product() { Name = "Product2", Size = 200 };
            _ct.Products.Add(Product1);
            _ct.Products.Add(Product2);
            _ct.SaveChanges();

            Catalog Catalog1 = new Catalog() { CatalogName = "Catalog1", Description = "Descript1" };
            Catalog Catalog2 = new Catalog() { CatalogName = "Catalog2", Description = "Descript2" };
            _ct.Catalogs.Add(Catalog1);
            _ct.Catalogs.Add(Catalog2);
            _ct.SaveChanges();

            Customer Customer1 = new Customer() { Name = "Customer1", Address = "Address1", Credit = Credit.good, Description = "Des1", Catalog = Catalog1 };
            Customer Customer2 = new Customer() { Name = "Customer2", Address = "Address2", Credit = Credit.good, Description = "Des2", Catalog = Catalog2 };
            _ct.Customers.Add(Customer1);
            _ct.Customers.Add(Customer2);
            _ct.SaveChanges();

            Contacter Contacter1 = new Contacter() { Name = "Contacter1", Telephones = "1234", Customer = Customer1 };
            Contacter Contacter2 = new Contacter() { Name = "Contacter2", Telephones = "1234", Customer = Customer1 };
            Contacter Contacter3 = new Contacter() { Name = "Contacter3", Telephones = "1234", Customer = Customer2 };
            _ct.Contacters.Add(Contacter1);
            _ct.Contacters.Add(Contacter2);
            _ct.Contacters.Add(Contacter3);
            _ct.SaveChanges();

            Order Order1 = new Order() { Contacter = Contacter1,/* Customer = Customer1,*/ Count = 10000, Product = Product1, /*CreatedTime = DateTime.Now,*/ TotalPrice = 100000, IsPayed = false, DestinationAddress = "Address1" };
            Order Order2 = new Order() { Contacter = Contacter2,/* Customer = Customer1,*/ Count = 10000, Product = Product2, /*CreatedTime = DateTime.Now,*/ TotalPrice = 100000, IsPayed = false, DestinationAddress = "Address2" };
            _ct.Orders.Add(Order1);
            _ct.Orders.Add(Order2);
            _ct.SaveChanges();
        }
    }
}
