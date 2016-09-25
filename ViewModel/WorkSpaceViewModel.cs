using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Threading;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using ERP.Auxiliary;

namespace ERP.ViewModel
{
    public class WorkSpaceViewModel:ViewModelBase
    {
        #region private members
        private string _currentTime;
        private string _statusMessage;
        private DispatcherTimer timer;
        private ViewModelBase _spaceDataContext;
        #endregion

        #region public properties
        public string CurrentTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                _currentTime = value;
                RaisePropertyChanged("");
            }
        }
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                RaisePropertyChanged("");
            }
        }
        public ViewModelBase SpaceDataContext
        {
            get
            {
                return _spaceDataContext;
            }
            set
            {
                _spaceDataContext = value;
                RaisePropertyChanged("");
            }
        }
        #endregion

        #region Commmnds
        private bool CanExecuteMenuClickCommand(string param)
        {
            return true;
        }
        private void ExecuteMenuClickCommand(string param)
        {
            DBAccess.UpdateChangedToDB();
            switch (param)
            {
                case "ProductsSpace_ViewModel": SpaceDataContext = ServiceLocator.Current.GetInstance<ProductsSpace_ViewModel>(); StatusMessage = "产品类型"; break;
                case "CustomerSpace": SpaceDataContext = ServiceLocator.Current.GetInstance<CustomerSpaceViewModel>(); StatusMessage = "客户类型"; break;
                case "OrdersSpaceViewModel": SpaceDataContext = ServiceLocator.Current.GetInstance<OrdersSpaceViewModel>();StatusMessage = "销售订单"; break;
            }
            
            
        }
        public ICommand MenuClickCommand
        {
            get
            {
                return new RelayCommand<string>(ExecuteMenuClickCommand, CanExecuteMenuClickCommand);
            }
        }
        #endregion

        #region private methods
        private void UpdateTime( object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
        #endregion

        #region Constructors
        public WorkSpaceViewModel()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += new EventHandler(UpdateTime);
            timer.Start();
            StatusMessage = "Null";
        }
        #endregion


        //#region private members
        //#endregion

        //#region public properties
        //#endregion

        //#region Commmnds
        //#endregion

        //#region private methods
        //#endregion

        //#region Constructors
        //#endregion

    }
}
