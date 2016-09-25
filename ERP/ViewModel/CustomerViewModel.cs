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
using ERP.View;
using System.Windows;

namespace ERP.ViewModel
{
    public class CustomerViewModel:ViewModelBase
    {
        private Customer _customer;
        private IViewModelFactory _ivf;
        private ObservableCollection<ContacterViewModel> _contacters;
        private ContacterViewModel _selectedContacter;
        private CatalogViewModel _catalog;

        public string Name
        {
            get
            {
                return _customer.Name;
            }
            set
            {
                if(value!=_customer.Name)
                {
                    _customer.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public string Address
        {
            get
            {
                return _customer.Address;
            }
            set
            {
                if(value!=_customer.Address)
                {
                    _customer.Address = value;
                    RaisePropertyChanged("Address");
                }
            }
        }
        public string Description
        {
            get
            {
                return _customer.Description;
            }
            set
            {
                if (value != _customer.Description)
                {
                    _customer.Description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }
        public int CustomerId
        {
            get
            {
                return _customer.CustomerId;
            }
        }
        public ObservableCollection<ContacterViewModel> Contacters
        {
            get
            {
                return _contacters;
            }
            set
            {
                _contacters = value;
                RaisePropertyChanged("Contacters");
            }
        }
        public ContacterViewModel SelectedContacter
        {
            get
            {
                return _selectedContacter ?? null;
            }
            set
            {
                _selectedContacter = value;
                RaisePropertyChanged("SelectedContacter");
            }
        }
        public CatalogViewModel Catalog
        {
            get
            {
                return _catalog;
            }
            set
            {
                if(value!=_catalog)
                {
                    _catalog = value;
                    RaisePropertyChanged("Catalog");
                }
            }
        }
        public Customer Customer
        {
            get
            {
                return _customer;
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
                case "Add": AddNewContacter(); break;
                case "Delete": DeleteContacter(); break;
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

        private void AddNewContacter()
        {
            if(!SaveToDb())
            {
                MessageBox.Show("请先提供客户名称，等信息");
                return;
            }
            ContacterListView clv = new ContacterListView();
            ViewModelLocator vml = Application.Current.Resources["Locator"] as ViewModelLocator;
            clv.DataContext = vml.ContacterListViewModel;
            vml.ContacterListViewModel.CurrentCustomer = this;
            _ivf.MarkContacterStatus(_customer.CustomerId, vml.ContacterListViewModel.ContacterList);
            foreach (Window each in Application.Current.Windows)
            {
                if (each.Title == "客户编辑")
                {
                    clv.Owner = each;
                }
            }
            clv.ShowDialog();
        }
        private void DeleteContacter()
        {
            ContacterViewModel deletedContacterViewModel = SelectedContacter;
            if (deletedContacterViewModel != null)
            {
                Contacters.Remove(deletedContacterViewModel);
                SelectedContacter = Contacters.FirstOrDefault();
                deletedContacterViewModel.RemoveDBRecord();
            }
        }

        public bool SaveToDb()
        {
            // we need to add process to modify the contacterlist here.
            if (Catalog == null)
                return false;
            _customer.Catalog = _ivf.GetCatalogFromCatalogViewModel(Catalog);
            return _ivf.Update(_customer);
        }
        public bool RemoveDBRecord()
        {
            return _ivf.DeleteCustomerById(_customer.CustomerId);
        }
        public void RefleshContacters()
        {
            Contacters = _ivf.GetContacterViewModels(_customer);
            SelectedContacter = Contacters.FirstOrDefault();
        }
        public void ContacterListChangedEventHandler(object sender, EventArgs args)
        {
            RefleshContacters();
        }

        public CustomerViewModel(Customer customer,IViewModelFactory ivf)
        {
            _customer = customer;
            _ivf = ivf;
            _contacters = _ivf.GetContacterViewModels(_customer);
            _selectedContacter = _contacters.FirstOrDefault();
            _catalog = _ivf.GetCatalogViewModel(_customer);
            _ivf.AttachContacterListChangedEvent(ContacterListChangedEventHandler);
        }
    }
}
