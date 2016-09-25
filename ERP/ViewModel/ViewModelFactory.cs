using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataRepository;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;

namespace ERP.ViewModel
{
    public class ViewModelFactory:IViewModelFactory
    {
        private UserViewModel _uvm;
        private WorkSpaceViewModel _wsv;
        private ProductsViewModel _psvm;
        private IDataRepository _idr;
        private CatalogsViewModel _csvm;
        private ContacterListViewModel _clvm;
        private CustomerListViewModel _customerListViewModel;
        private OrderListViewModel _orderListViewModel;

        public ViewModelFactory(IDataRepository idr)
        {
            _idr = idr;
        }

        public UserViewModel GetUserViewModel()
        {
            return _uvm;
        }
        public void CreateUserViewModel(User user)
        {
            _uvm = new UserViewModel(user, this, _idr);
        }

        public WorkSpaceViewModel GetWorkSpaceViewModel()
        {
            return _wsv;
        }
        public void CreateWorkSpaceViewModel()
        {
            _wsv = new WorkSpaceViewModel(this);
        }

        public ProductsViewModel GetProductsViewModel()
        {
            return _psvm;
        }
        public void CreateProductsViewModel()
        {
            ObservableCollection<ProductViewModel> productList = new ObservableCollection<ProductViewModel>();
            var tmp = _idr.GetProducts().ToList()
                .Select(e =>
                {
                    productList.Add(CreateProductViewModel(e));
                    return e;
                }).ToList();
            _psvm = new ProductsViewModel(productList, this);             
        }
        public ProductViewModel CreateProductViewModel(Product product)
        {
            return new ProductViewModel(product, _idr);
        }
        public ProductViewModel GetProductViewModel(int productId)
        {
            if(_psvm==null)
            {
                CreateProductsViewModel();
            }
            return _psvm.ProductList
                        .Where(t => t.ProductId == productId)
                        .FirstOrDefault();
        }
        public ProductViewModel GetProductViewModel(Product product)
        {
            return GetProductViewModel(product.ProductId);
        }

        public CatalogViewModel CreateCatalogViewModel()
        {
            Catalog catalog = new Catalog();
            if (_idr.Add(catalog) && _idr.SaveAll())
            {
                return new CatalogViewModel(catalog, this);
            }
            return null;
        }
        public CatalogViewModel GetCatalogViewModel(Catalog catalog)
        {
            return new CatalogViewModel(catalog, this);
        }
        public bool DeleteCatalog(int catalogId)
        {
            return _idr.DeleteCatalog(catalogId) && _idr.SaveAll();
        }
        public void CreateCatalogsViewModel()
        {
            ObservableCollection<CatalogViewModel> catalogList = new ObservableCollection<CatalogViewModel>();
            var tmp = _idr.GetCatalogs().ToList().Select(e =>
            {
                catalogList.Add(GetCatalogViewModel(e));
                return e;
            }).ToList();
            _csvm = new CatalogsViewModel(catalogList, this);
        }
        public CatalogsViewModel GetCatalogsViewModel()
        {
            return _csvm;
        }
        public bool Update(Catalog catalog)
        {
            Catalog originalCatalog = _idr.GetCatalog(catalog.CatalogId);
            if(originalCatalog!=null)
            {
                return _idr.Update(originalCatalog, catalog) && _idr.SaveAll();
            }
            else
            {
                return false;
            }
        }
        public CatalogViewModel GetCatalogViewModel(Customer customer)
        {
            if(_csvm==null)
            {
                CreateCatalogsViewModel();
            }
            Catalog catalog = _idr.GetCatalogByCustomer(customer);
            if (catalog == null)
                return _csvm.CatalogList.FirstOrDefault();
            return _csvm.CatalogList.Where(e => e.CatalogName == catalog.CatalogName).FirstOrDefault();
        }
        public Catalog GetCatalogFromCatalogViewModel(CatalogViewModel catalogvm)
        {
            if (catalogvm == null)
                return null;
            return _idr.GetCatalogByName(catalogvm.CatalogName);
        }

        public ContacterViewModel CreateContacterViewModel(CustomerViewModel customerowner)
        {
            Contacter newContacter = new Contacter();
            newContacter.Customer = customerowner.Customer;
            return CreateContacterViewModel(newContacter);
        }
        public ContacterViewModel CreateContacterViewModel(Contacter contacter)
        {
            return new ContacterViewModel(contacter, this);
        }
        public ContacterViewModel GetContacterViewModelById(int contacterId)
        {
            if(_clvm==null)
            {
                CreateContacterListViewModel();
            }
            return _clvm.ContacterList
                        .Where(t => t.ContacterId == contacterId)
                        .FirstOrDefault();
        }
        public Contacter GetContacterById(int contacterId)
        {
            return _idr.GetContacter(contacterId);
        }
        public bool Update(Contacter contacter)
        {
            Contacter originalContacter = GetContacterById(contacter.ContacterId);
            if (originalContacter == null)
            {
                return _idr.Add(contacter)&&_idr.SaveAll();
            }
            else
            return _idr.Update(originalContacter, contacter)&&_idr.SaveAll();
        }
        public bool DeleteContacter(int contacterId)
        {
            return _idr.DeleteContacterById(contacterId) && _idr.SaveAll();
        }
        public ContacterListViewModel GetContacterListViewModel()
        {
            return _clvm;
        }
        public void CreateContacterListViewModel()
        {
            ObservableCollection<ContacterViewModel> contacterList = new ObservableCollection<ContacterViewModel>();
            var tmp = _idr.GetContacters()
                            .ToList()
                            .Select(e =>
                            {
                                contacterList.Add(CreateContacterViewModel(e));
                                return e;
                            }).ToList();
            _clvm = new ContacterListViewModel(contacterList, this);
        }
        public ObservableCollection<ContacterViewModel> GetContacterViewModels(Customer customer)
        {
            ObservableCollection<ContacterViewModel> contacterViewModelList = new ObservableCollection<ContacterViewModel>();
            var tmp = _idr.GetContacters(customer).ToList().Select(e =>
            {
                contacterViewModelList.Add(CreateContacterViewModel(e));
                return e;
            }).ToList();
            return contacterViewModelList;
        }
        public void MarkContacterStatus(int customerId, ObservableCollection<ContacterViewModel> conterList)
        {
            var tmp = conterList.Select(e =>
            {
                e.IsSelected = e.CustomerId == customerId;
                return e;
            }).ToList();
        }
        public void UpdateCustomerIdForContacters()
        {
            if (_clvm == null || _clvm.CurrentCustomer==null)
                return;
            int customerId = _clvm.CurrentCustomer.CustomerId;
            var tmp = _clvm.ContacterList
                            .Select(e =>
                            {
                                if (e.IsSelected)
                                    e.CustomerId = customerId;
                                if(e.CustomerId==customerId && !e.IsSelected)
                                {
                                    e.RemoveDBRecord();
                                    return e;
                                }
                                e.SaveToDB();
                                return null;
                            }).ToList();
            var tmpnull = tmp.Select(t =>
            {
                if(t!=null)
                    _clvm.ContacterList.Remove(t);
                return t;
            }).ToList();
        }

        public CustomerViewModel CreateCustomerViewModel()
        {
            Customer customer = new Customer();
            return new CustomerViewModel(customer, this);
        }
        public CustomerViewModel CreateCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel(customer, this);
        }
        public bool Update(Customer customer)
        {
            Customer orignalCustomer = _idr.GetCustomer(customer.CustomerId);
            if (orignalCustomer == null)
            {
                return _idr.Add(customer) && _idr.SaveAll();
            }
            else
            {
                return _idr.Update(orignalCustomer, customer) && _idr.SaveAll();
            }
        }
        public bool DeleteCustomerById(int customerId)
        {
            return _idr.DeleteCustomer(customerId) && _idr.SaveAll();
        }
        public CustomerListViewModel GetCustomerListViewModel()
        {
            return _customerListViewModel;
        }
        public void CreateCustomerListViewModel()
        {
            ObservableCollection<CustomerViewModel> customerList = new ObservableCollection<CustomerViewModel>();
            var tmp = _idr.GetCustomers()
                            .ToList()
                            .Select(e =>
                            {
                                customerList.Add(CreateCustomerViewModel(e));
                                return e;
                            }).ToList();
            _customerListViewModel = new CustomerListViewModel(customerList, this);
        }
        public CustomerViewModel GetCustomerViewModelbyContacter(ContacterViewModel contactervm)
        {
            if(_customerListViewModel==null)
            {
                CreateCustomerListViewModel();
            }
            return _customerListViewModel.CustomerList
                                            .Where(t => t.CustomerId == contactervm.CustomerId)
                                            .FirstOrDefault();
        }

        public OrderListViewModel GetOrderListViewModel()
        {
            return _orderListViewModel;
        }
        public void CreateOrderListViewModel()
        {
            ObservableCollection<OrderViewModel> orderList = new ObservableCollection<OrderViewModel>();
            var tmp = _idr.GetOrders()
                            .ToList()
                            .Select(e =>
                            {
                                orderList.Add(CreateOrderViewModel(e));
                                return e;
                            }).ToList();
            _orderListViewModel = new OrderListViewModel(orderList, this);
        }
        public OrderViewModel CreateOrderViewModel(Order order)
        {
            return new OrderViewModel(order, this);
        }
        public OrderViewModel CreateOrderViewModel()
        {
            Order newOrder = new Order();
            return CreateOrderViewModel(newOrder);
        }
        public bool Update(Order order)
        {
            Order originalOrder = _idr.GetOrder(order.OrderId);
            if(originalOrder==null)
            {
                return _idr.Add(order) && _idr.SaveAll();
            }
            else
            {
                return _idr.Update(originalOrder, order) && _idr.SaveAll();
            }
        }
        public bool DeleteOrderById(int orderId)
        {
            return _idr.DeleteOrderById(orderId) && _idr.SaveAll();
        }

        public void AttachContacterListChangedEvent(ContacterListChangedEventHandler handler)
        {
            if(GetContacterListViewModel()==null)
            {
                CreateContacterListViewModel();
            }
            _clvm.ContacterListChangedEvent += handler;
        }
    }
}
