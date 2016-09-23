using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using ERP.ViewModel;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace ERP.Auxiliary.Converters
{
    public class CatalogsConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CatalogsViewModel csvm = value as CatalogsViewModel;
            if (csvm == null)
                return null;
            return csvm.CatalogList.Select(t => t.CatalogName).ToList<string>();

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string catalogName = value as string;
            return null;
        }
    }

    public class SelectedCatalogConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CatalogViewModel cvm = value as CatalogViewModel;
            if (cvm != null)
                return cvm.CatalogName;
            else
                return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string catalogName = value as string;
            ViewModelLocator vml = Application.Current.Resources["Locator"] as ViewModelLocator;

            return vml.CatalogsViewModel
                .CatalogList
                .Where(e => e.CatalogName == catalogName)
                .FirstOrDefault();
        }
    }

    public class SelectedProductConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ProductViewModel pvm = value as ProductViewModel;
            return pvm == null ? null : pvm.ProductName;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ProductName = value as string;
            ViewModelLocator vml = Application.Current.Resources["Locator"] as ViewModelLocator;
            return vml.ProductsViewModel
                        .ProductList
                        .Where(t =>
                        {
                            return t.ProductName == ProductName;
                        }).FirstOrDefault();
        }
    }

    public class ProductsConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ProductViewModel> Products = value as ObservableCollection<ProductViewModel>;
            return Products==null?null: Products.Select(t => t.ProductName).ToList();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;

        }
    }

    public class CustomersConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<CustomerViewModel> Customers = value as ObservableCollection<CustomerViewModel>;
            return Customers==null?null: Customers.Select(p => p.Name).ToList();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;

        }
    }
    public class SelectedCustomerConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CustomerViewModel SelectedCustomer = value as CustomerViewModel;
            return SelectedCustomer == null ? null : SelectedCustomer.Name;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string CustomerName = value as string;
            ViewModelLocator vml = Application.Current.Resources["Locator"] as ViewModelLocator;
            CustomerListViewModel customerListViewModel = vml.CustomerListViewModel;
            return customerListViewModel.CustomerList
                                        .Where(t =>
                                        {
                                            return t.Name == CustomerName;
                                        }).FirstOrDefault();
        }
    }
    //public class CatalogsConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        ObservableCollection<CustomerCatalog> Catalogs = value as ObservableCollection<CustomerCatalog>;
    //        return Catalogs.Select(p => p.CatalogName).ToList();
    //    }
    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return null;

    //    }
    //}
    //public class SelectedCatalogConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        CustomerCatalog cc = value as CustomerCatalog;
    //        return cc == null ? null : cc.CatalogName;
    //    }
    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        CustomerSpaceViewModel csvm = ServiceLocator.Current.GetInstance<CustomerSpaceViewModel>();
    //        string SelectedCatalogName = value as string;
    //        return csvm.Catalogs.Where(c => c.CatalogName == SelectedCatalogName).FirstOrDefault();

    //    }
    //}
    public class ContactersConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ContacterViewModel> contacters = value as ObservableCollection<ContacterViewModel>;
            return contacters==null?null:contacters.Select(p => p.Name).ToList();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;

        }
    }
    public class SelectedContacterConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ContacterViewModel contacter = value as ContacterViewModel;
            return contacter == null ? null : contacter.Name;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string contacterName = value as string;
            ViewModelLocator vml = Application.Current.Resources["Locator"] as ViewModelLocator;
            ObservableCollection<ContacterViewModel> contacterList=vml.OrderListViewModel.SelectedOrder.Customer.Contacters;
            //ObservableCollection<ContacterViewModel> contacterList = parameter as ObservableCollection<ContacterViewModel>;
            return contacterList
                        .Where(t => t.Name == contacterName)
                        .FirstOrDefault();
        }
    }
}
