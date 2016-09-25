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

namespace ViewModel
{
    public class ProductViewModel:ViewModelBase
    {
        #region private memebers
        private readonly Product _Product;
        private readonly IViewModelFactory _IVF;
        #endregion

        #region public properties
        public string ProductName
        {
            get
            {
                return _Product.Name;
            }
            set
            {
                if (value != _Product.Name)
                {
                    _Product.Name = value;
                    _IVF.Update(_Product);
                    RaisePropertyChanged("ProductName");
                }
            }
        }
        public int ProductSize
        {
            get
            {
                return _Product.Size;
            }
            set
            {
                if (value != _Product.Size)
                {
                    _Product.Size = value;
                    _IVF.Update(_Product);
                    RaisePropertyChanged("ProductSize");
                }
            }
        }
        public int Count
        {
            get
            {
                return _Product.Count;
            }
            set
            {
                if(value!=_Product.Count)
                {
                    _Product.Count = value;
                    _IVF.Update(_Product);
                    RaisePropertyChanged("Count");
                }
            }
        }
        #endregion

        #region Constructor
        public ProductViewModel(Product product,IViewModelFactory ivf)
        {
            _Product = product;
            _IVF = ivf;
        }
        #endregion
    }
}
