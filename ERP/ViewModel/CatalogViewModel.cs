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
    public class CatalogViewModel : ViewModelBase
    {
        #region private members
        private readonly Catalog _catalog;
        private readonly IViewModelFactory _ivf;
        #endregion

        #region public Properties
        public string CatalogName
        {
            get
            {
                return _catalog.CatalogName;
            }
            set
            {
                if (value != _catalog.CatalogName)
                {
                    _catalog.CatalogName = value;
                    RaisePropertyChanged("CatalogName");
                }
            }
        }
        public string Description
        {
            get
            {
                return _catalog.Description;
            }
            set
            {
                if(value!=_catalog.Description)
                {
                    _catalog.Description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }
        #endregion

        public bool DeleteDBRecord()
        {
            return _ivf.DeleteCatalog(_catalog.CatalogId);
        }
        public bool SaveDBEdit()
        {
            return _ivf.Update(_catalog);
        }

        #region Constructor
        public CatalogViewModel(Catalog catalog,IViewModelFactory ivf)
        {
            _catalog = catalog;
            _ivf = ivf;
        }
        #endregion
    }
}
