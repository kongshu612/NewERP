using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP.Auxiliary;

namespace ERP.ViewModel
{
    public class ProductsSpace_ViewModel:ViewModelBase
    {
        #region private members
        ObservableCollection<ProductDataVM> _products;
        ProductDataVM _selectedProduct;
        #endregion

        #region public properties
        public ObservableCollection<ProductDataVM> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                RaisePropertyChanged("");
            }
        }
        public ProductDataVM SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("");
            }
        }
        #endregion

        #region Commmnds
        private bool CanExecuteAddCommand()
        {
            return true;
        }
        private void ExecuteAddCommand()
        {
            ProductDataVM pdvm = new ProductDataVM();
            Products.Add(pdvm);
            SelectedProduct = pdvm;
        }
        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                _AddCommand= _AddCommand ?? new RelayCommand(ExecuteAddCommand, CanExecuteAddCommand);
                return _AddCommand;
            }            
        }
        private bool CanExecuteDeleteCommand()
        {
            return SelectedProduct == null ? false : true;
        }
        private void ExecuteDeleteCommand()
        {
            Products.Remove(SelectedProduct);
            int count = Products.Count;
            if(count==0)
                SelectedProduct=null;
            else
                SelectedProduct=Products[count-1];
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
        public ProductsSpace_ViewModel()
        {
            Products = new ObservableCollection<ProductDataVM>();
            var tmp = DBAccess.LoadProductsInfo().Select(e =>
            {
                Products.Add(new ProductDataVM(e));
                return e;
            }).ToArray();
            SelectedProduct = Products.FirstOrDefault();
        }
        #endregion
    }

    public class ProductDataVM:ViewModelBase
    {
        public Tab_Products _productDBInfo;
        #region private members
        private int _dbID;
        private string _productName;
        private int _productSize;
        #endregion

        #region public properties
        public int DBID
        {
            get
            {
                return _dbID;
            }
            set
            {
                _dbID = value;
                RaisePropertyChanged("");
            }
        }
        public string ProductName
        {
            get
            {
                return _productDBInfo.ProductName;
            }
            set
            {
                _productDBInfo.ProductName = value;
                RaisePropertyChanged("");
            }
        }
        public int ProductSize
        {
            get
            {
                return _productDBInfo.ProductSize;
            }
            set
            {
                _productDBInfo.ProductSize = value;
                RaisePropertyChanged("ProductSize");
            }
        }
        #endregion

        #region Commmnds
        #endregion
        


        #region private methods
        #endregion

        #region Constructors
        public ProductDataVM(int id, string name,int size)
        {
            _dbID = id;
            _productName = name;
            _productSize = size;
        }
        public ProductDataVM()
        { }
        public ProductDataVM(Tab_Products p)
        {
            _productDBInfo = p;
        }
        #endregion
    }
}
