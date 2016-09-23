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
using System.Windows.Data;
using ERP.ViewModel;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ProductsSpace.xaml
    /// </summary>
    public partial class ProductsSpace : UserControl
    {
        public ProductsSpace()
        {
            InitializeComponent();
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductsViewModel psvm = this.DataContext as ProductsViewModel;
            ProductConfigureView pcv = new ProductConfigureView();
            foreach(Window each in Application.Current.Windows)
            {
                if(each.Title== "ERP系统工作窗口")
                {
                    pcv.Owner = each;
                }
            }
            pcv.DataContext = psvm.SelectedProduct;
            pcv.ShowDialog();
        }
                
    }
}
