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
using DataRepository;

namespace ERP.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        #region private memebers
        public  Product _Product;
        public  IDataRepository _idr;
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
                    RaisePropertyChanged("ProductName");
                }
            }
        }
        public double ProductSize
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
                if (value != _Product.Count)
                {
                    _Product.Count = value;
                    RaisePropertyChanged("Count");
                }
            }
        }
        public int ProductId
        {
            get
            {
                return _Product.ProductId;
            }
        }
        #endregion

        public bool SaveToDb()
        {
            Product originalProduct = _idr.GetProduct(_Product.ProductId);
            return _idr.Update(originalProduct,_Product)&&_idr.SaveAll();
        }
        public bool DeleteDBRecord()
        {
            return _idr.DeleteProduct(_Product.ProductId)&&_idr.SaveAll();
        }
        public bool AddToDBRecord()
        {
            return _idr.Add(_Product) && _idr.SaveAll();
        }

        #region Constructor
        public ProductViewModel(Product product, IDataRepository idr)
        {
            _Product = product;
            _idr = idr;
        }
        #endregion
    }
}
