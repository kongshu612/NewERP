using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DBContext;

namespace DataRepository
{
    public class DataRepository:IDataRepository
    {
        #region private field and constructor
        private DataContext _dct;
        public DataRepository(DataContext dct)
        {
            _dct = dct;
        }
        #endregion

        #region User Table Operation
        /// <summary>
        /// This method is used to verify if the user is authenticated.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// bool type, true: authenticated user, false: unauthenticated.
        /// </returns>
        public bool IsUserValidate(string UserName, string Password)
        {
            return _dct.Users.Any(t => t.UserName==UserName&&t.Password==Password);             
        }
        #endregion

        #region Catalog Table
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public bool Add(Catalog catalog)
        {
            try
            {
                if (_dct.Catalogs.Any(t => t.CatalogName == catalog.CatalogName))
                    return false;
                _dct.Catalogs.Add(catalog);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public bool DeleteCatalog(int catalogId)
        {
            try
            {
                var targetCatalog = _dct.Catalogs.Find(catalogId);
                if (targetCatalog != null)
                {
                    _dct.Catalogs.Remove(targetCatalog);
                    return true;
                }
                else
                    return false;                    
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalCatalog"></param>
        /// <param name="updatedCatalog"></param>
        /// <returns></returns>
        public bool Update(Catalog originalCatalog, Catalog updatedCatalog)
        {
            try
            {
                _dct.Entry(originalCatalog).CurrentValues.SetValues(updatedCatalog);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CatalogId"></param>
        /// <returns></returns>
        public Catalog GetCatalog(int CatalogId)
        {
            return _dct.Catalogs.Find(CatalogId);
        }
        public Catalog GetCatalogByName(string catalogName)
        {
            return _dct.Catalogs
                .Where(e => e.CatalogName == catalogName)
                .FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Catalog GetCatalogByCustomer(Customer customer)
        {
            return customer.Catalog;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Catalog> GetCatalogs()
        {
            return _dct.Catalogs.AsQueryable();
        }
        #endregion

        #region Product Table
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public bool Add(Product newProduct)
        {
            try
            {
                if (_dct.Products.Any(t => t.ProductId == newProduct.ProductId))
                    return false;
                _dct.Products.Add(newProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            try
            {
                var targetProduct = _dct.Products.Find(productId);
                if (targetProduct == null)
                    return false;
                else
                {
                    _dct.Products.Remove(targetProduct);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalProduct"></param>
        /// <param name="updatedProduct"></param>
        /// <returns></returns>
        public bool Update(Product originalProduct, Product updatedProduct)
        {
            try
            {
                _dct.Entry(originalProduct).CurrentValues.SetValues(updatedProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Product GetProduct(int ProductId)
        {
            return _dct.Products.Find(ProductId);
        }
        public Product GetProduct(string ProductName, double ProductSize)
        {
            return _dct.Products.Where(e => e.Name == ProductName && e.Size == ProductSize).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetProducts()
        {
            return _dct.Products.AsQueryable();
        }
        #endregion

        #region Customer Table
        public bool Add(Customer customer)
        {
            if (_dct.Customers.Any(t => t.Name == customer.Name))
                return false;
            else
            {
                _dct.Customers.Add(customer);
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int customerId)
        {
            var customer = _dct.Customers.Find(customerId);
            if (customer != null)
            {
                _dct.Customers.Remove(customer);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalCustomer"></param>
        /// <param name="updatedCustomer"></param>
        /// <returns></returns>
        public bool Update(Customer originalCustomer, Customer updatedCustomer)
        {
            _dct.Entry(originalCustomer).CurrentValues.SetValues(updatedCustomer);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public Customer GetCustomer(int CustomerId)
        {
            return _dct.Customers.Include("Contacters").Where(t=>t.CustomerId==CustomerId).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contacter"></param>
        /// <returns></returns>
        public Customer GetCustomerByContacter(Contacter contacter)
        {
            return contacter.Customer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Customer GetCustomerByOrder(Order order)
        {
            return order.Contacter.Customer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public IQueryable<Customer> GetCustomersByCatalog(Catalog catalog)
        {
            return _dct.Customers.Where(t => t.Catalog == catalog).AsQueryable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Customer> GetCustomers()
        {
            return _dct.Customers.Include("Contacters").AsQueryable();
        }

        public Customer GetCustomerByProperties(string Name,string Address,string Description)
        {
           return  _dct.Customers
                .Include("Contacters")
                .Where(t => t.Name == Name && t.Address == Address && t.Description == Description)
                .FirstOrDefault();
        }
        #endregion

        #region Contacter table
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contacter"></param>
        /// <returns></returns>
        public bool Add(Contacter contacter)
        {
            if (_dct.Contacters.Any(t => t.Name == contacter.Name && t.Telephones == contacter.Telephones))
                return false;
            _dct.Contacters.Add(contacter);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContacterId"></param>
        /// <returns></returns>
        public bool DeleteContacterById(int ContacterId)
        {
            var targetContacter = _dct.Contacters.Find(ContacterId);
            if (targetContacter != null)
                _dct.Contacters.Remove(targetContacter);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalContacter"></param>
        /// <param name="updatedContacter"></param>
        public bool Update(Contacter originalContacter, Contacter updatedContacter)
        {
            try
            {
                _dct.Entry(originalContacter).CurrentValues.SetValues(updatedContacter);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contacterId"></param>
        /// <returns></returns>
        public Contacter GetContacter(int contacterId)
        {
            return _dct.Contacters.Find(contacterId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Contacter GetContacterByOrder(Order order)
        {
            return order.Contacter;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        public IQueryable<Contacter> GetContacters(Customer Customer)
        {
            return Customer.Contacters.AsQueryable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Contacter> GetContacters()
        {
            return _dct.Contacters.AsQueryable();
        }
        #endregion

        #region Order Table
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public bool Add(Order order)
        {
            try
            {
                _dct.Orders.Add(order);
                return true;
            }
            catch
            {
                return false;
            }            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool DeleteOrderById(int orderId)
        {
            var deletedOrder = _dct.Orders.Find(orderId);
            if(deletedOrder!=null)
            {
                _dct.Orders.Remove(deletedOrder);
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orginalOrder"></param>
        /// <param name="updatedOrder"></param>
        /// <returns></returns>
        public bool Update(Order orginalOrder, Order updatedOrder)
        {
            try
            {
                _dct.Entry(orginalOrder).CurrentValues.SetValues(updatedOrder);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order GetOrder(int orderId)
        {
            return _dct.Orders.Find(orderId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public IQueryable<Order> GetOrders(Customer customer)
        {
            return _dct.Orders.Where(e => e.Contacter.Customer == customer).AsQueryable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contacter"></param>
        /// <returns></returns>
        public IQueryable<Order> GetOrders(Contacter contacter)
        {
            return contacter.Orders.AsQueryable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Order> GetOrders()
        {
            List<Order> orders = _dct.Orders
                                     .Include("Contacter")
                                    .ToList();
            orders.ForEach(t => t.Customer = t.Contacter.Customer);
            return orders
                    .AsQueryable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IQueryable<Order> GetOrders(Product product)
        {
            return _dct.Orders.Where(t => t.ProductId == product.ProductId).AsQueryable();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SaveAll()
        {
            try
            {
                _dct.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
