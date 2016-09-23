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
using System.Windows.Shapes;
using ERP.ViewModel;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for OrderConfigurationView.xaml
    /// </summary>
    public partial class OrderConfigurationView : Window
    {
        public OrderConfigurationView()
        {
            InitializeComponent();
        }
        private void WndClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrderViewModel order = this.DataContext as OrderViewModel;
            if(!order.SaveDBRecord())
            {
                if(MessageBox.Show("Error occur,while saving to DB,Keep editting or discard it in DB","Error",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
