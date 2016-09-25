/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ERP"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ERP.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WorkSpaceViewModel>();
            SimpleIoc.Default.Register<ProductsSpace_ViewModel>();
            SimpleIoc.Default.Register<CustomerSpaceViewModel>();
            SimpleIoc.Default.Register<OrdersSpaceViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public WorkSpaceViewModel WorkSpace
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WorkSpaceViewModel>();
            }
        }
        public ProductsSpace_ViewModel ProductsSpace
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductsSpace_ViewModel>();
            }
        }
        public CustomerSpaceViewModel CustomerSpace
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomerSpaceViewModel>();
            }
        }
        public OrdersSpaceViewModel OrdersSpace
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrdersSpaceViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}