using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPWeb.ViewModels;
using Model;
using DataRepository;

namespace ERPWeb.Utility
{
    public interface IViewModelOperator
    {
        #region Products Operator
        List<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(int Id);
        bool UpdateProduct(int Id, ref ProductViewModel updatedProduct);
        bool InsertProduct(ref ProductViewModel addedProduct);
        bool DeleteProduct(int Id);
        #endregion

        #region Catalogs Operator
        List<CatalogsViewModel> GetCatalogs();
        CatalogsViewModel GetCatalog(int Id);
        bool UpdateCatalog(int Id, ref CatalogsViewModel updatedCatalog);
        bool InsertCatalog(ref CatalogsViewModel insertedCatalog);
        bool DeleteCatalog(int Id);
        #endregion

        #region Contacters Operator
        bool UpdateContacter(int Id, ref ContacterViewModel cvm);
        bool InsertContacter(ref ContacterViewModel cvm);
        ContacterViewModel GetContacter(int Id);
        List<ContacterViewModel> GetContacters(int customerId);
        bool DeleteContacter(int Id);
        #endregion

        #region Customers Operator
        List<CustomerViewModel> GetCustomers();
        CustomerViewModel GetCustomer(int Id);
        bool UpdateCustomer(int Id,ref CustomerViewModel cvm);
        bool InsertCustomer(ref CustomerViewModel cvm);
        bool DeleteCustomer(int Id);
        #endregion

        #region Orders Operator
        List<OrderViewModel> GetOrders();
        OrderViewModel GetOrder(int Id);
        bool UpdateOrder(int Id, ref OrderViewModel ovm);
        bool InsertOrder(ref OrderViewModel ovm);
        bool DeleteOrder(int Id);
        #endregion

    }
}
