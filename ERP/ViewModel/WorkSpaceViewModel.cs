﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Threading;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using ERP.Auxiliary;
using System.Windows;

namespace ERP.ViewModel
{
    public class WorkSpaceViewModel:ViewModelBase
    {
        private ViewModelBase _placeHolderViewModel;
        private readonly IViewModelFactory _ivf;

        public ViewModelBase PlaceHolderViewModel
        {
            get
            {
                return _placeHolderViewModel;
            }
            set
            {
                if(_placeHolderViewModel!=value)
                {
                    _placeHolderViewModel = value;
                    RaisePropertyChanged("PlaceHolderViewModel");
                }
            }
        }

        private bool CanExecuteMenuClickCommand(string param)
        {
            return true;
        }
        private void ExecuteMenuClickCommand(string param)
        {
            ViewModelLocator vml = Application.Current.Resources["Locator"] as ViewModelLocator;
            switch (param)
            {
                case "Products":
                    {                        
                        PlaceHolderViewModel = vml.ProductsViewModel;
                        break;
                    }
                case "Catalogs":
                    {
                        PlaceHolderViewModel = vml.CatalogsViewModel;
                        break;
                    }
                case "Customers":
                    {
                        PlaceHolderViewModel = vml.CustomerListViewModel;
                        break;
                    }
                case "Orders":
                    {
                        PlaceHolderViewModel = vml.OrderListViewModel;
                        break;
                    }
                //case "Customers": SpaceDataContext = ServiceLocator.Current.GetInstance<CustomerSpaceViewModel>(); StatusMessage = "客户类型"; break;
                //case "Orders": SpaceDataContext = ServiceLocator.Current.GetInstance<OrdersSpaceViewModel>(); StatusMessage = "销售订单"; break;
            }
        }
        public ICommand MenuClickCommand
        {
            get
            {
                return new RelayCommand<string>(ExecuteMenuClickCommand, CanExecuteMenuClickCommand);
            }
        }

        public WorkSpaceViewModel(IViewModelFactory ivf)
        {
            _ivf = ivf;
        }
    }
}
