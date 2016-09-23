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

namespace ERP.ViewModel
{
    public class CustomerListViewModel:ViewModelBase
    {
        private ObservableCollection<CustomerViewModel> _customerList;
        private IViewModelFactory _ivf;
        private CustomerViewModel _selectedCustomer;

        public ObservableCollection<CustomerViewModel> CustomerList
        {
            get
            {
                return _customerList;
            }
            set
            {
                _customerList = value;
                RaisePropertyChanged("CustomerList");
            }
        }
        public CustomerViewModel SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                if(value!=_selectedCustomer)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged("SelectedCustomer");
                }
            }
        }

        private bool CanExecuteButtonCommand(string parameter)
        {
            return true;
        }
        private void ExecuteButtonCommand(string parameter)
        {
            switch (parameter)
            {
                case "Add": AddNewCustomer(); break;
                case "Delete": DeleteCustomer(); break;
            }
        }
        private ICommand _ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                _ButtonCommand = _ButtonCommand ?? new RelayCommand<string>(ExecuteButtonCommand, CanExecuteButtonCommand);
                return _ButtonCommand;
            }
        }

        private void AddNewCustomer()
        {
            SelectedCustomer = _ivf.CreateCustomerViewModel();
            CustomerList.Add(SelectedCustomer);
        }
        private void DeleteCustomer()
        {
            CustomerViewModel deletedCustomer = SelectedCustomer;
            CustomerList.Remove(deletedCustomer);
            deletedCustomer.RemoveDBRecord();
            SelectedCustomer = CustomerList.FirstOrDefault();
        }

        public CustomerListViewModel(ObservableCollection<CustomerViewModel> customerList, IViewModelFactory ivf)
        {
            _customerList = customerList;
            _ivf = ivf;
            SelectedCustomer = _customerList.FirstOrDefault();
        }
    }
}
