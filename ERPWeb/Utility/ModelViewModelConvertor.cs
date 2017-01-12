using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWeb.ViewModels;
using Model;
using DataRepository;


namespace ERPWeb.Utility
{
    public class ModelViewModelConvertor:IModelViewModelConvertor
    {
        #region Depandency Injector
        public IDataRepository IDR { get; set; }
        #endregion
        public ProductViewModel ConvertToViewModel(Product _product)
        {
            if (_product == null)
                return null;
            ProductViewModel pvm = new ProductViewModel();
            pvm.Id = _product.ProductId;
            pvm.Name = _product.Name;
            pvm.Count = _product.Count;
            pvm.Size = _product.Size;
            return pvm;
        }

        public Product ConvertToModel(ProductViewModel _productViewModel)
        {
            if (_productViewModel == null)
                return null;
            Product product = IDR.GetProduct(_productViewModel.Id);
            if (product == null)
                product = new Product();
            product.Count = _productViewModel.Count;
            product.Name = _productViewModel.Name;
            product.Size = _productViewModel.Size;
            return product;
        }

        public CatalogsViewModel ConvertToViewModel(Catalog _catalog)
        {
            if (_catalog == null)
                return null;
            CatalogsViewModel cvm = new CatalogsViewModel();
            cvm.Id = _catalog.CatalogId;
            cvm.Name = _catalog.CatalogName;
            cvm.Description = _catalog.Description;
            return cvm;
        }
        public Catalog ConvertToModel(CatalogsViewModel _catalogViewModel)
        {
            if (_catalogViewModel == null)
                return null;
            Catalog catalog = IDR.GetCatalog(_catalogViewModel.Id);
            if (catalog == null)
                catalog = new Catalog();
            catalog.CatalogName = _catalogViewModel.Name;
            catalog.Description = _catalogViewModel.Description;
            return catalog;
        }
        public ContacterViewModel ConvertToViewModel(Contacter _contacter)
        {
            if (_contacter == null)
                return null;
            ContacterViewModel cvm = new ContacterViewModel();
            cvm.CustomerId = _contacter.CustomerId;
            cvm.Name = _contacter.Name;
            cvm.Id = _contacter.ContacterId;
            cvm.Telephones = _contacter.Telephones;
            return cvm;
        }
        public Contacter ConvertToModel(ContacterViewModel _contacterViewModel)
        {
            if (_contacterViewModel == null)
                return null;
            Contacter contacter = IDR.GetContacter(_contacterViewModel.Id);
            if (contacter == null)
                contacter = new Contacter();
            contacter.Name = _contacterViewModel.Name;
            contacter.Telephones = _contacterViewModel.Telephones;
            contacter.Customer = IDR.GetCustomer(_contacterViewModel.CustomerId);
            return contacter;
        }
        public CustomerViewModel ConvertToViewModel(Customer _customer)
        {
            if (_customer == null)
            {
                return null;
            }
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.Address = _customer.Address;
            cvm.Catalog = ConvertToViewModel(_customer.Catalog);
            _customer.Contacters.ToList()
                .ForEach(t => cvm.Contacters.Add(ConvertToViewModel(t)));
            cvm.Credit = "";
            cvm.Description = _customer.Description;
            cvm.Id = _customer.CustomerId;
            cvm.Name = _customer.Name;
            return cvm;
        }
        public Customer ConvertToModel(CustomerViewModel _customerViewModel)
        {
            if (_customerViewModel == null)
                return null;
            Customer customer = IDR.GetCustomer(_customerViewModel.Id);
            if (customer == null)
                customer = new Customer();
            customer.Name = _customerViewModel.Name;
            customer.Description = _customerViewModel.Description;
            customer.Credit = Credit.good;
            customer.Address = _customerViewModel.Address;
            Catalog catalog = ConvertToModel(_customerViewModel.Catalog);
            if (catalog != null)                 
                customer.Catalog = catalog;
            List<Contacter> contacterList = new List<Contacter>();
            _customerViewModel.Contacters
                .ForEach(t =>
                {
                    Contacter tmpContacter = ConvertToModel(t);
                    if (tmpContacter != null)
                    {
                        contacterList.Add(tmpContacter);
                    }
                });
            customer.Contacters = contacterList;
            return customer;
        }
        public OrderViewModel ConvertToViewModel(Order _order)
        {
            if (_order == null)
                return null;
            OrderViewModel ovm = new OrderViewModel();
            ovm.Count = _order.Count;
            ovm.CreatedTime = _order.CreatedTime;
            ovm.Description = _order.Description;
            ovm.DestinationAddress = _order.DestinationAddress;
            ovm.ExpressId = _order.ExpressId;
            ovm.IsPayed = _order.IsPayed;
            ovm.OrderId = _order.OrderId;
            ovm.SentTime = _order.SentTime;
            ovm.TotalPrice = _order.TotalPrice;
            ovm.Contacter = ConvertToViewModel(_order.Contacter);
            ovm.Customer = ConvertToViewModel(_order.Customer);
            ovm.Product = ConvertToViewModel(_order.Product);
            return ovm;
        }
        public Order ConvertToModel(OrderViewModel _orderViewModel)
        {
            if (_orderViewModel == null)
                return null;
            Order order = IDR.GetOrder(_orderViewModel.OrderId);
            if (order == null)
                order = new Order();
            order.Count = _orderViewModel.Count;
            order.CreatedTime = _orderViewModel.CreatedTime;
            order.Description = _orderViewModel.Description;
            order.DestinationAddress = _orderViewModel.DestinationAddress;
            order.ExpressId = _orderViewModel.ExpressId;
            order.IsPayed = _orderViewModel.IsPayed;
            order.SentTime = _orderViewModel.SentTime;
            order.TotalPrice = _orderViewModel.TotalPrice;
            Contacter contacter = ConvertToModel(_orderViewModel.Contacter);
            if (contacter != null)
                order.Contacter = contacter;
            Product product = ConvertToModel(_orderViewModel.Product);
            if (product != null)
                order.Product = product;
            order.Customer = contacter.Customer;
            return order;
        }
        public CreditViewModel ConvertToViewModel(Credit _credit)
        {
            return new CreditViewModel();
        }
        public Credit ConvertToModel(CreditViewModel _creditViewModel)
        {
            return Credit.good;
        }

        public ModelViewModelConvertor()
        {

        }
        public ModelViewModelConvertor(IDataRepository _idr)
        {
            IDR = _idr;
        }
    }
}