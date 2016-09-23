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
    /// Interaction logic for CustomerConfigurationView.xaml
    /// </summary>
    public partial class CustomerConfigurationView : Window
    {
        public CustomerConfigurationView()
        {
            InitializeComponent();
        }
        protected void HandleMouseDoubleClick(object sender, RoutedEventArgs args)
        {            
            CustomerViewModel cvm = this.DataContext as CustomerViewModel;
            ContacterConfigurationView ccv = new ContacterConfigurationView();
            foreach (Window each in Application.Current.Windows)
            {
                if (each.Title == "客户编辑")
                {
                    ccv.Owner = each;
                }
            }
            ccv.DataContext = cvm.SelectedContacter;
            ccv.ShowDialog();
        }

        private void WndClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CustomerViewModel cvm = this.DataContext as CustomerViewModel;
            if(!cvm.SaveToDb())
            {
                MessageBox.Show("Error occur while saving to DB");
                e.Cancel = true;
            }
        }
    }
}
