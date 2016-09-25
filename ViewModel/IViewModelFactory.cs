using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public interface IViewModelFactory
    {
        void Update(Product product);
    }
}
