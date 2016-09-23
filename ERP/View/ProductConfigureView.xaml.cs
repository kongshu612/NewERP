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
using Model;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ProductConfigureView.xaml
    /// </summary>
    public partial class ProductConfigureView : Window
    {
        public ProductConfigureView()
        {
            InitializeComponent();
        }

        private void Wnd_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProductViewModel pvm = this.DataContext as ProductViewModel;
            if(!pvm.SaveToDb())
            {
                e.Cancel = true;
                MessageBox.Show("Error occur while save to DB");
            }

        }
    }
}
