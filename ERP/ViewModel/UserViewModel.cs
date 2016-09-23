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
using System.Windows;
using ERP.View;

namespace ERP.ViewModel
{
    public class UserViewModel:ViewModelBase
    {
        private readonly User _user;
        private readonly IViewModelFactory _ivf;
        private readonly IDataRepository _idr;

        public string UserName
        {
            get
            {
                return _user.UserName;
            }
            set
            {
                if(value!=_user.UserName)
                {
                    _user.UserName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }
        public string Password
        {
            get
            {
                return _user.Password;
            }
            set
            {
                if(value!=_user.Password)
                {
                    _user.Password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        #region Commands
        private ICommand _buttonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return _buttonCommand;
            }
        }
        private void ExecuteButtonCommand(string parameter)
        {
            switch(parameter)
            {
                case "Login":Login(); break;
                case "Exit":break;
            }
        }
        private bool CanExecuteButtonCommand(string parameter)
        {
            return true;
        }
        private void Login()
        {
            if(_idr.IsUserValidate(UserName,Password))
            {
                //MessageBox.Show("Welcome");
                Application.Current.MainWindow.Hide();
                WorkSpace ws = new WorkSpace();
                ws.Show();                
            }
            else
            {
                UserName = "";
                Password = "";
            }
        }
        #endregion

        public UserViewModel(User user, IViewModelFactory ivf, IDataRepository idr)
        {
            _user = user;
            _ivf = ivf;
            _idr = idr;
            _buttonCommand = new RelayCommand<string>(ExecuteButtonCommand, CanExecuteButtonCommand);
        }
    }
}
