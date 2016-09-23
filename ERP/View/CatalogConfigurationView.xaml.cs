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
    /// Interaction logic for CatalogConfigurationView.xaml
    /// </summary>
    public partial class CatalogConfigurationView : Window
    {
        public CatalogConfigurationView()
        {
            InitializeComponent();
        }

        private void WndClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CatalogViewModel cvm = this.DataContext as CatalogViewModel;
            if(!cvm.SaveDBEdit())
            {
                MessageBox.Show("Error occur while updating DB");
                e.Cancel = true;
            }
        }
    }
}
