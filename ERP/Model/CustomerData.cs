using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ERP.Model
{
    public class CustomerInfo
    {
        #region private members
        private int _ID;
        private string _Name;
        private string _Address;
        private string _Description;
        private CustomerCatalogInfo _CatalogInfo;
        #endregion
        public int ID
        {
            get
            {
                return _ID;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
         }
        public CustomerCatalogInfo CatalogInfo
        {
            get
            {
                return _CatalogInfo;
            }
        }

    }

    public class CustomerCatalogInfo
    {
        #region private members
        private int _ID;
        private string _CatalogName;
        #endregion

        #region public properties
        public int ID
        {
            get
            {
                return _ID;
            }
        }
        public string CatalogName
        {
            get
            {
                return _CatalogName;
            }
            set
            {
                _CatalogName = value;
            }
        }
        #endregion
    }

}
