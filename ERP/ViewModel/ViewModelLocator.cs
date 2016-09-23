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
using DataRepository;
using Model;

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
            SimpleIoc.Default.Register<IDataRepository>(()=>new DataRepository.DataRepository(new DBContext.DataContext()));
            SimpleIoc.Default.Register<IViewModelFactory>(()=>new ViewModelFactory(SimpleIoc.Default.GetInstance<IDataRepository>()));
            //  SimpleIoc.Default.Register<ViewModelLocator>();
            //SimpleIoc.Default.Register<UserViewModel>((user, ivf, idr) => new UserViewModel(user, ivf, idr));
            //SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<WorkSpaceViewModel>();
            //SimpleIoc.Default.Register<ProductsSpace_ViewModel>();
            //SimpleIoc.Default.Register<CustomerSpaceViewModel>();
            //SimpleIoc.Default.Register<OrdersSpaceViewModel>();
        }

        public IViewModelFactory ViewModelFactory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IViewModelFactory>();
            }
        }
        public IDataRepository DataRepository
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDataRepository>();
            }
        }
        public UserViewModel UserViewModel
        {
            get
            {
                if (ViewModelFactory.GetUserViewModel() == null)
                {
                    ViewModelFactory.CreateUserViewModel(new User());
                }
                return ViewModelFactory.GetUserViewModel();
            }
        }        
        public WorkSpaceViewModel WorkSpaceViewModel
        {
            get
            {
                if(ViewModelFactory.GetWorkSpaceViewModel()==null)
                {
                    ViewModelFactory.CreateWorkSpaceViewModel();
                }
                return ViewModelFactory.GetWorkSpaceViewModel();
            }
        }
        public ProductsViewModel ProductsViewModel
        {
            get
            {
                if(ViewModelFactory.GetProductsViewModel()==null)
                {
                    ViewModelFactory.CreateProductsViewModel();
                }
                return ViewModelFactory.GetProductsViewModel();
            }
        }
        public CatalogsViewModel CatalogsViewModel
        {
            get
            {
                if(ViewModelFactory.GetCatalogsViewModel()==null)
                {
                    ViewModelFactory.CreateCatalogsViewModel();
                }
                return ViewModelFactory.GetCatalogsViewModel();
            }
        }
        public ContacterListViewModel ContacterListViewModel
        {
            get
            {
                if(ViewModelFactory.GetContacterListViewModel()==null)
                {
                    ViewModelFactory.CreateContacterListViewModel();
                }
                return ViewModelFactory.GetContacterListViewModel();
            }
        }
        public CustomerListViewModel CustomerListViewModel
        {
            get
            {
                if(ViewModelFactory.GetCustomerListViewModel()==null)
                {
                    ViewModelFactory.CreateCustomerListViewModel();
                }
                return ViewModelFactory.GetCustomerListViewModel();
            }
        }
        public OrderListViewModel OrderListViewModel
        {
            get
            {
                if(ViewModelFactory.GetOrderListViewModel()==null)
                {
                    ViewModelFactory.CreateOrderListViewModel();
                }
                return ViewModelFactory.GetOrderListViewModel();
            }
        }

        //public MainViewModel Main
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<MainViewModel>();
        //    }
        //}

        //public WorkSpaceViewModel WorkSpace
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<WorkSpaceViewModel>();
        //    }
        //}
        //public ProductsSpace_ViewModel ProductsSpace
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<ProductsSpace_ViewModel>();
        //    }
        //}
        //public CustomerSpaceViewModel CustomerSpace
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<CustomerSpaceViewModel>();
        //    }
        //}
        //public OrdersSpaceViewModel OrdersSpace
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<OrdersSpaceViewModel>();
        //    }
        //}

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}