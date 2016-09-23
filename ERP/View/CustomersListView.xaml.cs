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
    /// Interaction logic for CustomersListView.xaml
    /// </summary>
    public partial class CustomersListView : UserControl
    {
        public CustomersListView()
        {
            InitializeComponent();
        }
        protected void HandleMouseDoubleClick(object sender, RoutedEventArgs args)
        {
            CustomerListViewModel clvm = this.DataContext as CustomerListViewModel;
            CustomerConfigurationView ccv = new CustomerConfigurationView();
            ccv.DataContext = clvm.SelectedCustomer;
            foreach (Window each in Application.Current.Windows)
            {
                if (each.Title == "ERP系统工作窗口")
                {
                    ccv.Owner = each;
                }
            }
            ccv.ShowDialog();
        }
    }
}
