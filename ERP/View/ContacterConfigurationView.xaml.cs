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
    /// Interaction logic for ContacterConfigurationView.xaml
    /// </summary>
    public partial class ContacterConfigurationView : Window
    {
        public ContacterConfigurationView()
        {
            InitializeComponent();
        }

        private void WndClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContacterViewModel cvm = this.DataContext as ContacterViewModel;
            if(!cvm.SaveToDB())
            {
                MessageBox.Show("Error occur while saving to DB");
                e.Cancel = true;
            }
        }
    }
}
