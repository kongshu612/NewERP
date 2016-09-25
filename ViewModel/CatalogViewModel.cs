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
    public class CatalogViewModel:ViewModelBase
    {
        #region private members
        private readonly Catalog _catalog;
        private readonly IViewModelFactory _IVF;
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
                if(value!=_catalog.CatalogName)
                { }
            }
        }
        #endregion
    }
}
