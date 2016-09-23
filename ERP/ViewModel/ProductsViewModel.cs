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
    public class ProductsViewModel:ViewModelBase
    {
        private ObservableCollection<ProductViewModel> _productList;
        private ProductViewModel _selectedProduct;
        private IViewModelFactory _ivf;

        public ObservableCollection<ProductViewModel> ProductList
        {
            get
            {
                return _productList;
            }
            set
            {
                _productList = value;
                RaisePropertyChanged("ProductList");
            }
        }
        public ProductViewModel SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        private bool CanExecuteButtonCommand(string parameter)
        {
            return true;
        }
        private void ExecuteButtonCommand(string parameter)
        {
            switch(parameter)
            {
                case "Add": AddNewProduct(); break;
                case "Delete": DeleteProduct(); break;
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

        private void AddNewProduct()
        {
            Product addedProduct = new Product();            
            SelectedProduct = _ivf.CreateProductViewModel(addedProduct);
            SelectedProduct.AddToDBRecord();
            ProductList.Add(SelectedProduct);
        }
        private void DeleteProduct()
        {
            ProductViewModel pvm = SelectedProduct;
            ProductList.Remove(pvm);
            pvm.DeleteDBRecord();
            SelectedProduct = ProductList.FirstOrDefault();
        }

        public ProductsViewModel(ObservableCollection<ProductViewModel> productList,IViewModelFactory ivf)
        {
            _productList = productList;
            _selectedProduct = _productList.FirstOrDefault();
            _ivf = ivf;
        }
    }
}
