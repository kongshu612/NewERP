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
    /// Interaction logic for CustomerSpace.xaml
    /// </summary>
    public partial class CustomerSpace : UserControl
    {
        public CustomerSpace()
        {
            InitializeComponent();
        }

        private void lvSelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItem == null)
                return;
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
            lcv.MoveCurrentTo(lv.SelectedItem);
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem lvi = sender as ListViewItem;
            NewContact ncwin = new NewContact();
            ncwin.DataContext = lvi.DataContext;
            ncwin.ShowDialog();
        }
    }
}
