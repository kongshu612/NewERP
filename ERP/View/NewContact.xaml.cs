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
using System.Windows.Shapes;
using ERP.Auxiliary;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for NewContact.xaml
    /// </summary>
    public partial class NewContact : Window
    {
        public NewContact()
        {
            InitializeComponent();
        }

        private void win_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txt_Name.Text))
            {
                MessageBox.Show("您必须给联系人提供一个姓名");
                return;
            }
            DBAccess.UpdateChangedToDB();
        }
    }
}
