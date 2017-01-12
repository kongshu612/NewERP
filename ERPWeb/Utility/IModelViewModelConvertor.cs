using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPWeb.ViewModels;
using Model;

namespace ERPWeb.Utility
{
    public interface IModelViewModelConvertor
    {
        ProductViewModel ConvertToViewModel(Product _product);
        Product ConvertToModel(ProductViewModel _productViewModel);

        CatalogsViewModel ConvertToViewModel(Catalog _catalog);
        Catalog ConvertToModel(CatalogsViewModel _catalogViewModel);

        ContacterViewModel ConvertToViewModel(Contacter _contacter);
        Contacter ConvertToModel(ContacterViewModel _contacterViewModel);

        CustomerViewModel ConvertToViewModel(Customer _customer);
        Customer ConvertToModel(CustomerViewModel _customerViewModel);

        OrderViewModel ConvertToViewModel(Order _order);
        Order ConvertToModel(OrderViewModel _orderViewModel);

        CreditViewModel ConvertToViewModel(Credit _credit);
        Credit ConvertToModel(CreditViewModel _creditViewModel);
    }
}
