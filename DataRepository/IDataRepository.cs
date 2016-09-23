using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DBContext;

namespace DataRepository
{
    public interface IDataRepository
    {
        bool IsUserValidate(string UserName, string Password);

        bool Add(Catalog catalog);
        bool DeleteCatalog(int catalogId);
        bool Update(Catalog originalCatalog, Catalog updatedCatalog);
        Catalog GetCatalog(int CatalogId);
        Catalog GetCatalogByCustomer(Customer customer);
        IQueryable<Catalog> GetCatalogs();
        Catalog GetCatalogByName(string catalogName);

        bool Add(Product newProduct);
        bool DeleteProduct(int productId);
        bool Update(Product originalProduct, Product updatedProduct);
        Product GetProduct(int ProductId);
        Product GetProduct(string ProductName, double ProductSize);
        IQueryable<Product> GetProducts();

        bool Add(Customer customer);
        bool DeleteCustomer(int customerId);
        bool Update(Customer originalCustomer, Customer updatedCustomer);
        Customer GetCustomer(int CustomerId);
        Customer GetCustomerByContacter(Contacter contacter);
        Customer GetCustomerByOrder(Order order);
        IQueryable<Customer> GetCustomersByCatalog(Catalog catalog);
        IQueryable<Customer> GetCustomers();

        bool Add(Contacter Contacter);
        bool DeleteContacterById(int ContacterId);
        bool Update(Contacter originalContacter, Contacter updatedContacter);
        Contacter GetContacter(int ContacterId);
        Contacter GetContacterByOrder(Order order);
        IQueryable<Contacter> GetContacters(Customer Customer);
        IQueryable<Contacter> GetContacters();

        bool Add(Order order);
        bool DeleteOrderById(int orderId);
        bool Update(Order orginalOrder, Order updatedOrder);
        Order GetOrder(int orderId);
        IQueryable<Order> GetOrders(Customer customer);
        IQueryable<Order> GetOrders(Contacter contacter);
        IQueryable<Order> GetOrders();
        IQueryable<Order> GetOrders(Product product);

        bool SaveAll();
    }
}
