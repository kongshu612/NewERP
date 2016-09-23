using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Threading;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using ERP.Auxiliary;

namespace ERP.ViewModel
{
    public class OrdersSpaceViewModel:ViewModelBase
    {
        public ObservableCollection<Tab_Orders> _orderCollectionDB;
        #region private members
        private ObservableCollection<OrderViewModel> _Orders;
        private OrderViewModel _SelectedOrder;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region public properties
        public ObservableCollection<OrderViewModel> Orders
        {
            get
            {
                if(_Orders==null)
                {
                    _Orders = new ObservableCollection<OrderViewModel>();
                    var tmp = _orderCollectionDB.Select(e =>
                    {
                        _Orders.Add(new OrderViewModel(e));
                        return e;
                    }).ToArray();
                }
                return _Orders;
            }
        }
        public OrderViewModel SelectedOrder
        {
            get
            {
                return _SelectedOrder;
            }
            set
            {
                _SelectedOrder = value;
                RaisePropertyChanged("");
            }
        }
        #endregion

        #region Commmnds
        private void ExecuteAddCommand()
        {
            Tab_Orders newOrder = new Tab_Orders();
            SelectedOrder = new OrderViewModel(newOrder);
            Orders.Add(SelectedOrder);
            _orderCollectionDB.Add(newOrder);
        }
        private bool CanExecuteAddCommand()
        {
            return true;
        }
        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                _AddCommand = _AddCommand ?? new RelayCommand(ExecuteAddCommand, CanExecuteAddCommand);
                return _AddCommand;
            }
        }
        private void ExecuteDeleteCommand()
        {
            Orders.Remove(SelectedOrder);
            _orderCollectionDB.Remove(SelectedOrder._orderDBInfo);
            SelectedOrder = Orders.FirstOrDefault();
        }
        private bool CanExecuteDeleteCommand()
        {
            return SelectedOrder != null;
        }
        private ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                _DeleteCommand = _DeleteCommand ?? new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
                return _DeleteCommand;
            }
        }
        #endregion

        #region private methods
        #endregion

        #region Constructors
        public OrdersSpaceViewModel()
        {
            _orderCollectionDB = DBAccess.LoadOrdersInfo();
        }
        #endregion
    }

    //public class OrderViewModel :ViewModelBase
    //{
    //    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //    public Tab_Orders _orderDBInfo;
    //    #region private members
    //    private Customer _SelectedCustomer;
    //    private ProductDataVM _SelectedProduct;
    //    private Contact _SelectedContact;
    //    private int _PricePer;
    //    private int _TotalCount;
    //    private int _TotalPrice;
    //    private bool _IsPayed;
    //    private string _SendTime;
    //    private string _Description;
    //    private string _MailID;
    //    #endregion

    //    #region public properties
    //    public Customer SelectedCustomer
    //    {
    //        get
    //        {
    //            if (_orderDBInfo.Tab_Customers == null)
    //            {
    //                log.Debug("the selected Customer value is undefined");
    //                return null;
    //            }
    //            _SelectedCustomer = _SelectedCustomer ?? new Customer(_orderDBInfo.Tab_Customers);
    //            return _SelectedCustomer;
    //        }
    //        set
    //        {
    //            if (value != null && _SelectedCustomer != value)
    //            {
    //                _SelectedCustomer = value;
    //                _orderDBInfo.Tab_Customers = _SelectedCustomer._customersDB;
    //                RaisePropertyChanged("SelectedCustomer");
    //            }
    //        }
    //    }
    //    public ProductDataVM SelectedProduct
    //    {
    //        get
    //        {
    //            if(_orderDBInfo.Tab_Products==null)
    //            {
    //                log.Debug("the Products value in the order is underfined");
    //                return null;
    //            }
    //            _SelectedProduct = _SelectedProduct ?? new ProductDataVM(_orderDBInfo.Tab_Products);
    //            return _SelectedProduct;
    //        }
    //        set
    //        {
    //            if (value != null && _SelectedProduct != value)
    //            {
    //                _SelectedProduct = value;
    //                _orderDBInfo.Tab_Products = _SelectedProduct._productDBInfo;
    //                RaisePropertyChanged("SelectedProduct");
    //            }
    //        }
    //    }
    //    public Contact SelectedContact
    //    {
    //        get
    //        {
    //            if(_orderDBInfo.Tab_CustomerContacts==null)
    //            {
    //                log.Debug("the Selected Contact is empty");
    //                return null;
    //            }
    //            _SelectedContact = _SelectedContact ?? new Contact(_orderDBInfo.Tab_CustomerContacts);
    //            return _SelectedContact;
    //        }
    //        set
    //        {
    //            if (value != null && value != _SelectedContact)
    //            {
    //                _SelectedContact = value;
    //                _orderDBInfo.Tab_CustomerContacts = _SelectedContact._ContactInfo;
    //                RaisePropertyChanged("SelectedContact");
    //            }
    //        }
    //    }
    //    public long PricePer
    //    {
    //        get
    //        {
    //            return _orderDBInfo.PricePer;
    //        }
    //        set
    //        {
    //            _orderDBInfo.PricePer = value;
    //            RefleshTotalPrice();
    //            RaisePropertyChanged("");
    //        }
    //    }
    //    public long TotalCount
    //    {
    //        get
    //        {
    //            return _orderDBInfo.TotalCount;
    //        }
    //        set
    //        {
    //            _orderDBInfo.TotalCount = value;
    //            RefleshTotalPrice();
    //            RaisePropertyChanged("");
    //        }
    //    }
    //    public long TotalPrice
    //    {
    //        get
    //        {
    //            return _orderDBInfo.TotalPrice;
    //        }
    //        set
    //        {
    //            _orderDBInfo.TotalPrice = value;
    //            RaisePropertyChanged("TotalPrice");
    //        }
    //    }
    //    public string SendTime
    //    {
    //        get
    //        {
    //            return _orderDBInfo.SendTime;
    //        }
    //        set
    //        {
    //            _orderDBInfo.SendTime = value;
    //            RaisePropertyChanged("");
    //        }
    //    }
    //    public string Description
    //    {
    //        get
    //        {
    //            return _orderDBInfo.Description;
    //        }
    //        set
    //        {
    //            _orderDBInfo.Description = value;
    //            RaisePropertyChanged("Description");
    //        }
    //    }
    //    public string MailID
    //    {
    //        get
    //        {
    //            return _orderDBInfo.MailID;
    //        }
    //        set
    //        {
    //            _orderDBInfo.MailID = value;
    //            RaisePropertyChanged("MailID");
    //        }
    //    }
    //    public bool IsPayed
    //    {
    //        get
    //        {
    //            return _orderDBInfo.IsPayed;
    //        }
    //        set
    //        {
    //            _orderDBInfo.IsPayed = value;
    //            RaisePropertyChanged("IsPayed");
    //        }
    //    }
    //    #endregion

    //    #region Commmnds
    //    #endregion

    //    #region private methods
    //    private void RefleshTotalPrice()
    //    {
    //        TotalPrice = TotalCount * PricePer;
    //    }
    //    #endregion

    //    #region Constructors
    //    public OrderViewModel()
    //    {
            
    //    }
    //    public OrderViewModel(Tab_Orders orderDB)
    //    {
    //        _orderDBInfo = orderDB;
    //    }
    //    #endregion

    //}
}
