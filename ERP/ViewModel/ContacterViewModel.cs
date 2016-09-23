using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using DataRepository;

namespace ERP.ViewModel
{
    public class ContacterViewModel:ViewModelBase
    {
        private  Contacter _contacter;
        private  IViewModelFactory _ivf;
        private bool _isSelected;

        public string Name
        {
            get
            {
                return _contacter.Name;
            }
            set
            {
                if(value!=_contacter.Name)
                {
                    _contacter.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public string Telephones
        {
            get
            {
                return _contacter.Telephones;
            }
            set
            {
                if(value!=_contacter.Telephones)
                {
                    _contacter.Telephones = value;
                    RaisePropertyChanged("Telephones");
                }
            }
        }        
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
        public int CustomerId
        {
            get
            {
                return _contacter.CustomerId;
            }
            set
            {
                if(value!=_contacter.CustomerId)
                {
                    _contacter.CustomerId = value;
                    SaveToDB();
                }
            }
        }
        public int ContacterId
        {
            get
            {
                return _contacter.ContacterId;
            }
        }

        public bool SaveToDB()
        {
            return _ivf.Update(_contacter);
        }
        public bool RemoveDBRecord()
        {
            return _ivf.DeleteContacter(_contacter.ContacterId);
        }


        public ContacterViewModel(Contacter contacter,IViewModelFactory ivf)
        {
            _contacter = contacter;
            _ivf = ivf;
        }
    }
}
