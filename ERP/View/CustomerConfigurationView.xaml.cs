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
                if (MessageBox.Show("客户信息无法保存，检查是否提供了姓名等信息。确定：重新编辑，取消：数据无法保存", "Error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
