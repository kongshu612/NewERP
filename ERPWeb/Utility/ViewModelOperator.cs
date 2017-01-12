using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWeb.ViewModels;
using Model;
using DataRepository;

namespace ERPWeb.Utility
{
    public class ViewModelOperator : IViewModelOperator
    {
        #region dependency Injector
        private IDataRepository _idr;
        public IDataRepository IDR
        {
            get { return _idr; }
            set { _idr = value; }
        }
        private IModelViewModelConvertor _im2vm;
        public IModelViewModelConvertor IM2VM
        {
            get { return _im2vm; }
            set { _im2vm = value; }
        }
        #endregion

        #region Products Implementation
        public List<ProductViewModel> GetProducts()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            IDR.GetProducts().ToList().ForEach(t =>
            {
                productList.Add(IM2VM.ConvertToViewModel(t));
            });
            return productList;
        }

        public ProductViewModel GetProduct(int Id)
        {
            Product product = IDR.GetProduct(Id);
            if (product == null)
                return null;
            return IM2VM.ConvertToViewModel(product);
        }

        public bool UpdateProduct(int Id, ref ProductViewModel updatedProduct)
        {
            Product sourceProduct = IDR.GetProduct(Id);
            if (sourceProduct == null || updatedProduct==null)
                return false;
            Product updatedProductModel = IM2VM.ConvertToModel(updatedProduct);
            if (IDR.Update(sourceProduct, updatedProductModel)&&IDR.SaveAll())
            {
                updatedProduct = GetProduct(Id);
                return true;
            }
            else
                return false;
        }

        public bool InsertProduct(ref ProductViewModel addedProduct)
        {
            if (addedProduct == null)
                return false;
            Product addedProductModel = IM2VM.ConvertToModel(addedProduct);
            if (IDR.Add(addedProductModel) && IDR.SaveAll())
            {
                addedProduct = IM2VM.ConvertToViewModel(addedProductModel);
                return true;
            }
            else
                return false;
        }

        public bool DeleteProduct(int Id)
        {
            return IDR.DeleteProduct(Id) && IDR.SaveAll();
        }
        #endregion

        #region Catalogs Implementation
        public List<CatalogsViewModel> GetCatalogs()
        {
            List<Catalog> catalogList = IDR.GetCatalogs().ToList();
            List<CatalogsViewModel> catalogVMList = new List<CatalogsViewModel>();
            catalogList.ForEach(t => catalogVMList.Add(IM2VM.ConvertToViewModel(t)));
            return catalogVMList;
        }
        public CatalogsViewModel GetCatalog(int Id)
        {
            Catalog catalog = IDR.GetCatalog(Id);
            if (catalog == null)
                return null;
            return IM2VM.ConvertToViewModel(catalog);
        }
        public bool UpdateCatalog(int Id, ref CatalogsViewModel updatedCatalog)
        {
            Catalog catalog = IDR.GetCatalog(Id);
            if (catalog == null||updatedCatalog==null)
                return false;
            Catalog updatedModelCatalog = IM2VM.ConvertToModel(updatedCatalog);
            if (IDR.Update(catalog, updatedModelCatalog) && IDR.SaveAll())
            {
                updatedCatalog = GetCatalog(Id);
                return true;
            }
            else
                return false;
        }
        public bool InsertCatalog(ref CatalogsViewModel insertedCatalog)
        {
            Catalog insertedModelCatalog = IM2VM.ConvertToModel(insertedCatalog);
            if (IDR.Add(insertedModelCatalog) && IDR.SaveAll())
            {
                insertedCatalog = IM2VM.ConvertToViewModel(insertedModelCatalog);
                return true;
            }
            else
                return false;
        }
        public bool DeleteCatalog(int Id)
        {
            if (IDR.DeleteCatalog(Id) && IDR.SaveAll())
                return true;
            else
                return false;
        }
        #endregion

        #region Contacters Implementation
        public List<ContacterViewModel> GetContacters(int customerId)
        {
            List<ContacterViewModel> contacterList = new List<ContacterViewModel>();
            IDR.GetContacters()
                .Where(t => t.CustomerId == customerId)
                .ToList()
                .ForEach(e => contacterList.Add(IM2VM.ConvertToViewModel(e)));
            return contacterList;
        }
        public ContacterViewModel GetContacter(int Id)
        {
            Contacter contacter = IDR.GetContacter(Id);
            if (contacter == null)
                return null;
            return IM2VM.ConvertToViewModel(contacter);
        }
        public bool UpdateContacter(int Id, ref ContacterViewModel cvm)
        {
            Contacter originalContacter = IDR.GetContacter(Id);
            if (originalContacter == null||cvm==null)
                return false;
            Contacter updatedContacter = IM2VM.ConvertToModel(cvm);
            if (IDR.Update(originalContacter, updatedContacter) && IDR.SaveAll())
            {
                cvm = GetContacter(Id);
                return true;
            }
            else
                return false;
        }
        public bool InsertContacter(ref ContacterViewModel cvm)
        {
            if (cvm == null)
                return false;
            Contacter insertedContacter = IM2VM.ConvertToModel(cvm);
            if (IDR.Add(insertedContacter) && IDR.SaveAll())
            {
                cvm = IM2VM.ConvertToViewModel(insertedContacter);
                return true;
            }
            else
                return false;
        }
        public bool DeleteContacter(int Id)
        {
            if (IDR.DeleteContacterById(Id) && IDR.SaveAll())
            {
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Customers Implementation
        public List<CustomerViewModel> GetCustomers()
        {
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();
            IDR.GetCustomers()
                .ToList()
                .ForEach(t => customerList.Add(IM2VM.ConvertToViewModel(t)));
            return customerList;
        }
        public CustomerViewModel GetCustomer(int Id)
        {
            return IM2VM.ConvertToViewModel(IDR.GetCustomer(Id));
        }
        public bool UpdateCustomer(int Id, ref CustomerViewModel cvm)
        {
            Catalog targetCatalog = IDR.GetCatalog(cvm.Catalog.Id);
            Customer originalCustomer = IDR.GetCustomer(Id);
            if (originalCustomer == null)
                return false;
            Customer updatedCustomer = IM2VM.ConvertToModel(cvm);
            if (IDR.Update(originalCustomer, updatedCustomer) && IDR.SaveAll())
            {
                return true;
            }
            else
                return false;
        }
        public bool InsertCustomer(ref CustomerViewModel cvm)
        {
            if (cvm == null)
                return false;
            Customer insertedModel = IM2VM.ConvertToModel(cvm);
            if (IDR.Add(insertedModel) && IDR.SaveAll())
            {
                cvm = IM2VM.ConvertToViewModel(insertedModel);
                return true;                
            }
            else
                return false;
        }
        public bool DeleteCustomer(int Id)
        {            
            if (IDR.DeleteCustomer(Id)&& IDR.SaveAll())
                return true;
            else
                return false;
        }
        #endregion

        #region Orders Implementation
        public List<OrderViewModel> GetOrders()
        {
            List<OrderViewModel> ordersList = new List<OrderViewModel>();
            IDR.GetOrders().ToList()
                .ForEach(t => ordersList.Add(IM2VM.ConvertToViewModel(t)));
            return ordersList;
        }
        public OrderViewModel GetOrder(int Id)
        {
            return IM2VM.ConvertToViewModel(IDR.GetOrder(Id));
        }
        public bool UpdateOrder(int Id, ref OrderViewModel ovm)
        {
            Order originalOrder = IDR.GetOrder(Id);
            if (originalOrder == null||ovm==null)
                return false;
            Order updatedOrder = IM2VM.ConvertToModel(ovm);
            if (IDR.Update(originalOrder, updatedOrder) && IDR.SaveAll())
            {
                ovm = GetOrder(Id);
                return true;
            }
            else
                return false;
        }
        public bool InsertOrder(ref OrderViewModel ovm)
        {
            if (ovm == null)
                return false;
            Order orderModel = IM2VM.ConvertToModel(ovm);
            if (IDR.Add(orderModel) && IDR.SaveAll())
            {
                ovm = IM2VM.ConvertToViewModel(orderModel);
                return true;
            }
            else
                return false;
        }
       public bool DeleteOrder(int Id)
        {
            if (IDR.DeleteOrderById(Id) && IDR.SaveAll())
                return true;
            else
                return false;
        }
        #endregion

        #region Constuctor
        public ViewModelOperator()
        {

        }

        public ViewModelOperator(IDataRepository idr,IModelViewModelConvertor im2vm)
        {
            IDR = idr;
            IM2VM = im2vm;
        }
        #endregion

    }
}