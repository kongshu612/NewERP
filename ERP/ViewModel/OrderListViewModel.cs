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
    public class OrderListViewModel:ViewModelBase
    {
        private ObservableCollection<OrderViewModel> _orderList;
        private OrderViewModel _selectedOrder;
        private IViewModelFactory _ivf;

        public ObservableCollection<OrderViewModel> OrderList
        {
            get
            {
                return _orderList;
            }
            set
            {
                _orderList = value;
                RaisePropertyChanged("OrderList");
            }
        }
        public OrderViewModel SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                if(value!=_selectedOrder)
                {
                    _selectedOrder = value;
                    RaisePropertyChanged("SelectedOrder");
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
                case "Add": AddNewOrder(); break;
                case "Delete": DeleteOrder(); break;
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

        private void AddNewOrder()
        {
            OrderViewModel newOrdervm = _ivf.CreateOrderViewModel();
            OrderList.Add(newOrdervm);
            SelectedOrder = newOrdervm;
        }
        private void DeleteOrder()
        {
            if (SelectedOrder == null)
                return;
            OrderViewModel deletedOrdervm = SelectedOrder;
            OrderList.Remove(SelectedOrder);
            SelectedOrder = OrderList.FirstOrDefault();
            deletedOrdervm.DeleteDBRecord();
        }

        public OrderListViewModel(ObservableCollection<OrderViewModel> orderList,IViewModelFactory ivf)
        {
            _orderList = orderList;
            _ivf = ivf;
            SelectedOrder = _orderList.FirstOrDefault();
        }
    }
}
