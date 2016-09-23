using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Collections.ObjectModel;

namespace ERP.Auxiliary
{
    public class DBAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static Model1 DBInstance;

        static DBAccess()
        {
            DBInstance = new Model1();
        }
        public static ObservableCollection<Tab_CustomerCatalog> LoadCatalogInfo()
        {
            return new ObservableCollection<Tab_CustomerCatalog>(DBInstance.Tab_CustomerCatalog.ToArray());
        }
        public static ObservableCollection<Tab_Customers> LoadCustomersInfo()
        {
            return new ObservableCollection<Tab_Customers>(DBInstance.Tab_Customers.ToArray());
        }
        public static ObservableCollection<Tab_Credit> LoadCreditsInfo()
        {
            return new ObservableCollection<Tab_Credit>(DBInstance.Tab_Credit.ToArray())
;       }
        public static void UpdateChangedToDB()
        {
            DBInstance.SaveChanges();
        }
        public static ObservableCollection<Tab_Products> LoadProductsInfo()
        {
            return new ObservableCollection<Tab_Products>(DBInstance.Tab_Products.ToArray());
        }
        public static ObservableCollection<Tab_Orders> LoadOrdersInfo()
        {
            return new ObservableCollection<Tab_Orders>(DBInstance.Tab_Orders.ToArray());
        }
    }
}
