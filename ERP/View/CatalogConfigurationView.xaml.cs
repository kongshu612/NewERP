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
                if (MessageBox.Show("类别信息无法保存，检查是否提供了姓名等信息。确定：重新编辑，取消：数据无法保存", "Error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
