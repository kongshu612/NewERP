﻿using System;
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
    /// Interaction logic for CatalogListView.xaml
    /// </summary>
    public partial class CatalogListView : UserControl
    {
        public CatalogListView()
        {
            InitializeComponent();
        }
        protected void HandleMouseDoubleClick(object sender,RoutedEventArgs args)
        {
            CatalogsViewModel csvm = this.DataContext as CatalogsViewModel;
            CatalogConfigurationView ccv = new CatalogConfigurationView();
            foreach (Window each in Application.Current.Windows)
            {
                if (each.Title == "ERP系统工作窗口")
                {
                    ccv.Owner = each;
                }
            }
            ccv.DataContext = csvm.SelectedCatalog;
            ccv.ShowDialog();
        }
    }
}
