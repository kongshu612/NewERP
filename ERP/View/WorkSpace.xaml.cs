﻿using System;
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
using System.Windows.Shapes;
using ERP.Auxiliary;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for WorkSpace.xaml
    /// </summary>
    public partial class WorkSpace : Window
    {
        public WorkSpace()
        {
            InitializeComponent();
        }

        private void win_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
