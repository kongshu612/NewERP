using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;

namespace ERP.ViewModel
{
    public class OrderViewModel:ViewModelBase
    {
        private Order _order;
        private IViewModelFactory _ivf;
        private CustomerViewModel _customerViewModel;
        private ContacterViewModel _contacterViewModel;
        private ProductViewModel _productViewModel;
             
        public CustomerViewModel Customer
        {
            get
            {
                return _customerViewModel;
            }
            set
            {
                _customerViewModel = value;
                RaisePropertyChanged("Customer");
                RaisePropertyChanged("CatalogName");
                RaisePropertyChanged("ContacterList");
            }
        }
        public ProductViewModel Product
        {
            get
            {
                return _productViewModel;
            }
            set
            {
                _productViewModel = value;
                RaisePropertyChanged("Product");
            }
        }
        public ContacterViewModel Contacter
        {
            get
            {
                return _contacterViewModel;
            }
            set
            {
                _contacterViewModel = value;
                RaisePropertyChanged("Contacter");
                RaisePropertyChanged("Telephones");
            }
        }  
        public string Telephones
        {
            get
            {
                return _contacterViewModel==null?null:_contacterViewModel.Telephones;
            }
        }
        public double TotalCount
        {
            get
            {
                return _order.Count;
            }
            set
            {
                if(value!=_order.Count)
                {
                    _order.Count = value;
                    RaisePropertyChanged("TotalCount");
                }
            }
        }
        public double TotalPrice
        {
            get
            {
                return _order.TotalPrice;
            }
            set
            {
                if(value!=_order.TotalPrice)
                {
                    _order.TotalPrice = value;
                    RaisePropertyChanged("TotalPrice");
                }
            }
        }
        public string CatalogName
        {
            get
            {
                if (_customerViewModel == null)
                    return null;
                return _customerViewModel.Catalog.CatalogName;
            }
        }
        public ObservableCollection<ContacterViewModel> ContacterList
        {
            get
            {
                if (_customerViewModel == null)
                    return null;
                return _customerViewModel.Contacters;
            }
        }
        //public string SendTime
        //{
        //    get
        //    {
        //        return _orderDBInfo.SendTime;
        //    }
        //    set
        //    {
        //        _orderDBInfo.SendTime = value;
        //        RaisePropertyChanged("");
        //    }
        //}
        public string Description
        {
            get
            {
                return _order.Description;
            }
            set
            {
                if(value!=_order.Description)
                {
                    _order.Description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }
        public string ExpressId
        {
            get
            {
                return _order.ExpressId;
            }
            set
            {
                if(value!=_order.ExpressId)
                {
                    _order.ExpressId = value;
                    RaisePropertyChanged("ExpressId");
                }
            }
        }
        public bool IsPayed
        {
            get
            {
                return _order.IsPayed;
            }
            set
            {
                if(value!=_order.IsPayed)
                {
                    _order.IsPayed = value;
                    RaisePropertyChanged("IsPayed");
                }
            }
        }
        public string DestinationAddress
        {
            get
            {
                return _order.DestinationAddress;
            }
            set
            {
                _order.DestinationAddress = value;
                RaisePropertyChanged("DestinationAddress");
            }
        }

        public bool ValidateProperties()
        {
            return Product.ProductId != 0 && Contacter.ContacterId != 0&&!string.IsNullOrEmpty(DestinationAddress);
        }
        public bool SaveDBRecord()
        {
            if (Product == null || Contacter == null)
                return false;
            _order.ProductId = Product.ProductId;
            _order.ContacterId = Contacter.ContacterId;
            if (!ValidateProperties())
                return false;
            return _ivf.Update(_order);
        }
        public bool DeleteDBRecord()
        {
            return _ivf.DeleteOrderById(_order.OrderId);
        }
        
        public OrderViewModel(Order order, IViewModelFactory ivf)
        {
            _order = order;
            _ivf = ivf;
            ViewModelLocator vml = Application.Current.Resources["Locator"] as ViewModelLocator;
            Contacter = _ivf.GetContacterViewModelById(_order.ContacterId);
            Customer = Contacter==null?null:_ivf.GetCustomerViewModelbyContacter(Contacter);
            Product = _ivf.GetProductViewModel(_order.ProductId);
        }

    }
}
