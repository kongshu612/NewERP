using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP.Auxiliary;
using Model;
using DataRepository;

namespace ERP.ViewModel
{
   
    public class ContacterListViewModel:ViewModelBase
    {
        private ObservableCollection<ContacterViewModel> _contacterList;
        private IViewModelFactory _ivf;
        private ContacterViewModel _selectedContacter;

        public ObservableCollection<ContacterViewModel> ContacterList
        {
            get
            {
                return _contacterList;
            }
            set
            {
                _contacterList = value;
                RaisePropertyChanged("ContacterList");
            }
        }
        public ContacterViewModel SelectedContacter
        {
            get
            {
                return _selectedContacter;
            }
            set
            {
                if(value!=_selectedContacter)
                {
                    _selectedContacter = value;
                    RaisePropertyChanged("SelectedContacter");
                }
            }
        }
        public CustomerViewModel CurrentCustomer
        { get; set; }
        public event ContacterListChangedEventHandler ContacterListChangedEvent;

        public void OnContacterListChangedEventHandler(EventArgs args)
        {
            if(ContacterListChangedEvent != null)
            {
                ContacterListChangedEvent(this, args);
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
            SelectedContacter = _ivf.CreateContacterViewModel(CurrentCustomer);
           // SelectedContacter.AddToDBRecord();
            ContacterList.Add(SelectedContacter);
        }
        private void DeleteContacter()
        {
            ContacterViewModel deletedContacter = SelectedContacter;
            ContacterList.Remove(deletedContacter);
            deletedContacter.RemoveDBRecord();
            SelectedContacter = ContacterList.FirstOrDefault();
        }
        public void SaveContactersToDB()
        {
            _ivf.UpdateCustomerIdForContacters();
        }

        public ContacterListViewModel(ObservableCollection<ContacterViewModel> clvm,IViewModelFactory ivf)
        {
            _contacterList = clvm;
            _ivf = ivf;
            SelectedContacter = _contacterList.FirstOrDefault();
        }
    }
}
