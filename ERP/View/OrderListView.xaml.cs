using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ERP.ViewModel;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for OrderListView.xaml
    /// </summary>
    public partial class OrderListView : UserControl
    {
        public OrderListView()
        {
            InitializeComponent();
        }

        protected void HandleMouseDoubleClick(object sender, RoutedEventArgs args)
        {
            OrderListViewModel orderlist = this.DataContext as OrderListViewModel;
            if (orderlist == null || orderlist.SelectedOrder==null)
                return;
            OrderConfigurationView ocv = new OrderConfigurationView();
            foreach (Window each in Application.Current.Windows)
            {
                if (each.Title == "ERP系统工作窗口")
                {
                    ocv.Owner = each;
                }
            }
            ocv.DataContext = orderlist.SelectedOrder;
            ocv.ShowDialog();
        }
    }
}
