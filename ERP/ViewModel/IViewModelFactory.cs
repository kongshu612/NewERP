using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using DataRepository;

namespace ERP.ViewModel
{
    public interface IViewModelFactory
    {
        UserViewModel GetUserViewModel();
        void CreateUserViewModel(User user);

        WorkSpaceViewModel GetWorkSpaceViewModel();
        void CreateWorkSpaceViewModel();

        void CreateProductsViewModel();
        ProductsViewModel GetProductsViewModel();
        ProductViewModel CreateProductViewModel(Product product);
        ProductViewModel GetProductViewModel(int productId);
        ProductViewModel GetProductViewModel(Product product);

        CatalogViewModel CreateCatalogViewModel();
        bool DeleteCatalog(int catalogId);
        CatalogsViewModel GetCatalogsViewModel();
        CatalogViewModel GetCatalogViewModel(Catalog catalog);
        void CreateCatalogsViewModel();
        bool Update(Catalog catalog);
        CatalogViewModel GetCatalogViewModel(Customer customer);
        Catalog GetCatalogFromCatalogViewModel(CatalogViewModel catalogvm);

        ContacterViewModel CreateContacterViewModel(CustomerViewModel customerowner);
        ContacterViewModel CreateContacterViewModel(Contacter contacter);
        ContacterViewModel GetContacterViewModelById(int contacterId);
        Contacter GetContacterById(int contacterId);
        bool Update(Contacter contacter);
        bool DeleteContacter(int contacterId);
        ContacterListViewModel GetContacterListViewModel();
        void CreateContacterListViewModel();
        void MarkContacterStatus(int customerId,ObservableCollection<ContacterViewModel> conterList);
        void UpdateCustomerIdForContacters();
        ObservableCollection<ContacterViewModel> GetContacterViewModels(Customer customer);

        CustomerViewModel CreateCustomerViewModel();
        bool Update(Customer customer);
        bool DeleteCustomerById(int customerId);
        CustomerListViewModel GetCustomerListViewModel();
        void CreateCustomerListViewModel();
        CustomerViewModel GetCustomerViewModelbyContacter(ContacterViewModel contactervm);

        OrderListViewModel GetOrderListViewModel();
        void CreateOrderListViewModel();
        OrderViewModel CreateOrderViewModel(Order order);
        OrderViewModel CreateOrderViewModel();
        bool Update(Order order);
        bool DeleteOrderById(int orderId);

        void AttachContacterListChangedEvent(ContacterListChangedEventHandler handler);

        //void Update(Product product);
        //void Update(Catalog catalog);

        //void Update(Customer customer);
        //void Update(Customer customer, CatalogViewModel cvm);
        //ObservableCollection<ContacterViewModel> GetContacterViewModels(Customer customer);
        //CatalogViewModel GetCatalogViewModel(Customer customer);
        //CustomerViewModel GetCustomerViewModel(Customer customer);
        //Customer ParseCustomer(CustomerViewModel customerViewModel);

        //void Update(Contacter catalog);
        //ContacterViewModel GetContacterViewModel(Contacter contacter);
        //Contacter ParseContacter(ContacterViewModel contacterViewModel);

        //CustomerViewModel GetCustomerViewModel(Order order);
        //void Update(Order order, Product newProduct);
        //void Update(Order order, Contacter newContacter);
        //void Update(Order order);

        //ProductViewModel GetProductViewModel(Product product);
        //Product ParseProduct(ProductViewModel productViewModel);

    }
}
