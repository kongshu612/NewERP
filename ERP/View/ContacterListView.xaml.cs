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
    /// Interaction logic for ContacterListView.xaml
    /// </summary>
    public partial class ContacterListView : Window
    {
        public ContacterListView()
        {
            InitializeComponent();
        }
        protected void HandleDoubleClick(object sender, RoutedEventArgs args)
        {
            ContacterListViewModel clvm = this.DataContext as ContacterListViewModel;
            ContacterConfigurationView ccv = new ContacterConfigurationView();
            foreach (Window each in Application.Current.Windows)
            {
                if (each.Title == "联系人列表编辑")
                {
                    ccv.Owner = each;
                }
            }
            ccv.DataContext = clvm.SelectedContacter;
            ccv.ShowDialog();
        }

        private void WndClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContacterListViewModel clvm = this.DataContext as ContacterListViewModel;
            clvm.SaveContactersToDB();
            clvm.OnContacterListChangedEventHandler(null);
            clvm.CurrentCustomer.RefleshContacters();
        }
    }
}
