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
using System.IO;

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
            CreateShortCut();
        }

        private void win_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
        private void CreateShortCut()
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string shortCutFullPath = deskDir + "\\ERP.url";
            if (File.Exists(shortCutFullPath))
            {
                return;
            }
            using (StreamWriter writer = new StreamWriter(shortCutFullPath))
            {
                string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
                writer.Flush();
            }
            return;
        }
    }
}
