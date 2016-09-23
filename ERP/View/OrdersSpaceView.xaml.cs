using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for OrdersSpaceView.xaml
    /// </summary>
    public partial class OrdersSpaceView : UserControl
    {
        public OrdersSpaceView()
        {
            InitializeComponent();
        }
        
        private void Event_MouseDoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = sender as ListViewItem;
            OrderViewModel ovm = lvi.DataContext as OrderViewModel;
            OrderView ov = new OrderView();
            ov.DataContext = ovm;
            ov.ShowDialog();
        }
    }
}
