using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using ERP.Auxiliary;

namespace ERP.ViewModel
{
    public class CustomerSpaceViewModel:ViewModelBase
    {
        #region private members
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        private ObservableCollection<CustomerCatalog> _catalogs;
        #endregion

        #region public properties
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
                RaisePropertyChanged("Customers");
            }
        }
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                DBAccess.UpdateChangedToDB();
                RaisePropertyChanged("SelectedCustomer");
            }
        }

        public ObservableCollection<CustomerCatalog> Catalogs
        {
            get
            {
                if (_catalogs == null)
                    LoadCustomerCatalog();
                return _catalogs;
            }
        }

        #endregion

        #region Commmnds
        private bool CanExecuteAddCommand(string param)
        {
            return true;
        }
        private void ExecuteAddCommand(string param)
        {
            Tab_Customers newCustomer = new Tab_Customers();
            DBAccess.LoadCustomersInfo().Add(newCustomer);
            SelectedCustomer = new Customer(newCustomer);
            Customers.Add(SelectedCustomer);
            
        }
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                _addCommand = _addCommand ?? new RelayCommand<string>(ExecuteAddCommand, CanExecuteAddCommand);
                return _addCommand;
            }
        }

        private bool CanExecuteDeleteCommand(string param)
        {
            return SelectedCustomer == null ? false : true;
        }
        private void ExecuteDeleteCommand(string param)
        {
            DBAccess.LoadCustomersInfo().Remove(SelectedCustomer._customersDB);
            Customers.Remove(SelectedCustomer);
            SelectedCustomer = Customers.Count == 0 ? null : Customers[Customers.Count - 1];
        }
        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                _deleteCommand = _deleteCommand ?? new RelayCommand<string>(ExecuteDeleteCommand, CanExecuteDeleteCommand);
                return _deleteCommand;
            }
        }
        #endregion

        #region private methods
        private void LoadCustomerCatalog()
        {
            _catalogs = new ObservableCollection<CustomerCatalog>();
            var tmp = ERP.Auxiliary.DBAccess.LoadCatalogInfo().Select(e =>
            {
                _catalogs.Add(new CustomerCatalog(e));
                return e;
            }
            ).ToArray();
        }
        #endregion

        #region Constructors
        public CustomerSpaceViewModel()
        {
            _customers = new ObservableCollection<Customer>();
            var tmp = DBAccess.LoadCustomersInfo().Select(e =>
            {
                _customers.Add(new Customer(e));
                return e;
            }).ToArray();
            SelectedCustomer = _customers.FirstOrDefault();
        }
        #endregion

        //#region private members
        //#endregion

        //#region public properties
        //#endregion

        //#region Commmnds
        //#endregion

        //#region private methods
        //#endregion

        //#region Constructors
        //#endregion
    }

    public class Customer:ViewModelBase
    {
        public Tab_Customers _customersDB;
        #region private members
        private ObservableCollection<Contact> _contacts;
        private Contact _selectedContact;
        #endregion

        #region public properties
        public string Name
        {
            get
            {
                return _customersDB == null ? null : _customersDB.CName;
            }
            set
            {
                _customersDB.CName = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Address
        {
            get
            {
                return _customersDB == null ? null : _customersDB.CAddress;
            }
            set
            {
                _customersDB.CAddress = value;
                RaisePropertyChanged("Address");
            }
        }
        public string Description
        {
            get
            {
                return _customersDB==null ? null : _customersDB.CDescription;
            }
            set
            {
                _customersDB.CDescription = value;
                RaisePropertyChanged("Description");
            }
        }        
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                if(_contacts==null)
                {
                    _contacts = new ObservableCollection<Contact>();
                    var tmp = _customersDB.Tab_CustomerContacts.Select(e =>
                    {
                        _contacts.Add(new Contact(e));
                        return e;
                    }).ToArray();
                }
                return _contacts;
            }
            set
            {
                _contacts = value;
                RaisePropertyChanged("Contacts");
            }
        }
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact??null;
            }
            set
            {
                _selectedContact = value;
                RaisePropertyChanged("SelectedContact");
            }
        }
        public CustomerCatalog Catalog
        {
            get
            {
                return new CustomerCatalog(_customersDB.Tab_CustomerCatalog);
            }
            set
            {
                
                _customersDB.Tab_CustomerCatalog = DBAccess.LoadCatalogInfo().Where(e => e.CatalogName == value.CatalogName).FirstOrDefault();
                RaisePropertyChanged("Catalog");
            }
        }
        #endregion

        #region Commmnds
        private bool CanExecuteAddCommand(string param)
        {
            return true;
        }
        private void ExecuteAddCommand(string param)
        {
             Tab_CustomerContacts newContact = new Tab_CustomerContacts();
            newContact.FK_Customer_ID = _customersDB.ID;
            _customersDB.Tab_CustomerContacts.Add(newContact);
            SelectedContact = new Contact(newContact);
            Contacts.Add(SelectedContact);
        }
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                _addCommand = _addCommand ?? new RelayCommand<string>(ExecuteAddCommand, CanExecuteAddCommand);
                return _addCommand;
            }
        }

        private bool CanExecuteDeleteCommand(string param)
        {
            return SelectedContact == null ? false : true;
        }
        private void ExecuteDeleteCommand(string param)
        {
            _customersDB.Tab_CustomerContacts.Remove(SelectedContact._ContactInfo);
            Contacts.Remove(SelectedContact); 
            SelectedContact = Contacts.Count == 0 ? null : Contacts[Contacts.Count - 1];
        }
        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                _deleteCommand = _deleteCommand ?? new RelayCommand<string>(ExecuteDeleteCommand, CanExecuteDeleteCommand);
                return _deleteCommand;
            }
        }
        #endregion

        #region public methods
        //public  string Tostring()
        //{
        //    return Name;
        //}
        public Customer( Tab_Customers c)
        {
            _customersDB = c;
        }
        public Customer()
        {
            _customersDB = new Tab_Customers();
        }
        #endregion

        //#region private methods
        //#endregion

        //#region Constructors
        //#endregion
    }
    public class Contact:ViewModelBase
    {
        public Tab_CustomerContacts _ContactInfo;
        #region private members
        private ObservableCollection<Tab_Credit> _creditsDB;
        private ObservableCollection<Credit> _credits;
        #endregion

        #region public properties
        public string Name
        {
            get
            {
                return _ContactInfo.ContactName;
            }
            set
            {
                _ContactInfo.ContactName = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Telphone
        {
            get
            {
                return _ContactInfo.ContactTelphone;
            }
            set
            {
                _ContactInfo.ContactTelphone = value;
                RaisePropertyChanged("Telphone");
            }
        }
        public string Description
        {
            get
            {
                return _ContactInfo.ContactDescription;
            }
            set
            {
                _ContactInfo.ContactDescription = value;
                RaisePropertyChanged("Description");
            }
        }
        public Credit CreditInfo
        {
            get
            {
                return _ContactInfo.Tab_Credit==null?Credit.good: ConvertToCredit(_ContactInfo.Tab_Credit.CreditPriority);
            }
            set
            {
                int t = ConvertToInt(value);
                _ContactInfo.Tab_Credit = _creditsDB.Where(e => e.CreditPriority == t).FirstOrDefault();
                RaisePropertyChanged("CreditInfo");
            }
        }

        public ObservableCollection<Credit> Credits
        {
            get
            {
               if(_credits==null)
                {
                    _credits = new ObservableCollection<Credit>();
                    var tmp = _creditsDB.Select(e =>
                    {
                        _credits.Add(ConvertToCredit(e.CreditPriority));
                        return e;
                    }).ToArray();
                }
                return _credits;
            }
        }
        #endregion

        #region Commmnds
        #endregion

        #region public methods
        public string Tostring()
        {
            return Name;
        }
        public static Credit ConvertToCredit(int c)
        {
            switch(c)
            {
                case 1: return Credit.perfect;
                case 2: return Credit.good;
                case 3: return Credit.normal;
                default:return Credit.bad;
            }
        }
        public static int ConvertToInt(Credit c)
        {
            switch(c)
            {
                case Credit.perfect: return 1;
                case Credit.good:return 2;
                case Credit.normal:return 3;
                default:return 4;
            }
        }
        #endregion

        #region private methods
        #endregion

        #region Constructors
        public Contact()
        {
            _ContactInfo = new Tab_CustomerContacts();
            _creditsDB = DBAccess.LoadCreditsInfo();
        }
        public Contact(Tab_CustomerContacts contactDB):this()
        {
            _ContactInfo = contactDB;
            

        }
        #endregion

    }
    public enum Credit{perfect=1,good=2,normal=3,bad=4}
    public class CustomerCatalog:ViewModelBase
    {

        #region private members
        private int _id;
        private string _catalogName;
        private Tab_CustomerCatalog _catalogInfo;
        #endregion

        #region public properties
        public string CatalogName
        {
            get
            {
                return _catalogInfo==null?null:_catalogInfo.CatalogName;
            }
        }
        #endregion

        #region Commmnds
        #endregion

        #region private methods
        #endregion

        #region Constructors
        public CustomerCatalog()
        {
            _catalogInfo = new Tab_CustomerCatalog();
        }
        public CustomerCatalog(string name)
        {
            _catalogName = name;
        }
        public CustomerCatalog(Tab_CustomerCatalog catalogInfo)
        {
            _catalogInfo = catalogInfo;
        }
        #endregion

    }
}
