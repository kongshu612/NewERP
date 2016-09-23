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
    public class CatalogsViewModel:ViewModelBase
    {
        private ObservableCollection<CatalogViewModel> _catalogList;
        private CatalogViewModel _selectedCatalog;
        private IViewModelFactory _ivf;

        public ObservableCollection<CatalogViewModel> CatalogList
        {
            get
            {
                return _catalogList;
            }
            set
            {
                _catalogList = value;
                RaisePropertyChanged("CatalogList");
            }
        }
        public CatalogViewModel SelectedCatalog
        {
            get
            {
                return _selectedCatalog;
            }
            set
            {
                if(value!=_selectedCatalog)
                {
                    _selectedCatalog = value;
                    RaisePropertyChanged("SelectedCatalog");
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
                case "Add": AddNewCatalog(); break;
                case "Delete": DeleteCatalog(); break;
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

        private void AddNewCatalog()
        {
            CatalogViewModel addedCatalogViewModel = _ivf.CreateCatalogViewModel();
            if(addedCatalogViewModel!=null)
            {
                CatalogList.Add(addedCatalogViewModel);
                SelectedCatalog = addedCatalogViewModel;
            }
        }
        private void DeleteCatalog()
        {
            CatalogViewModel deletedCatalogViewModel = SelectedCatalog;
            if(deletedCatalogViewModel!=null)
            {
                CatalogList.Remove(deletedCatalogViewModel);
                SelectedCatalog = CatalogList.FirstOrDefault();
                deletedCatalogViewModel.DeleteDBRecord();
            }
        }

        public CatalogsViewModel(ObservableCollection<CatalogViewModel> catalogList,IViewModelFactory ivf)
        {
            _catalogList = catalogList;
            _ivf = ivf;
            _selectedCatalog = _catalogList.FirstOrDefault();
        }
    }
}
