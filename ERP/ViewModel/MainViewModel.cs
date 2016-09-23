using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ERP.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        //#region private members
        //#endregion

        //#region public properties
        //#endregion

        //#region Commmnds
        //#endregion

        //#region private methods
        //#endregion

        #region private members
        private string _userName;
        private string _pwd;
        #endregion

        #region public properties
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged("");
            }
        }

        public string PWD
        {
            get
            {
                return _pwd;
            }
            set
            {
                _pwd = value;
                RaisePropertyChanged("");
            }
        }
        #endregion

        #region Commmnds
        public ICommand OKCommand
        {
            get
            {
                return _okCommand ??
                    (_okCommand = new RelayCommand(ExecuteOkCommand, CanExecuteOkCommand));
            }
        }
        private ICommand _okCommand;
        private void ExecuteOkCommand()
        { }
        private bool CanExecuteOkCommand()
        {
            return true;
        }

       
        private ICommand _exitCommand;
        private void ExecuteExitCommand()
        { }
        private bool CanExecuteExitCommand()
        {
            return true;
        }
        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand ??
                    (_exitCommand = new RelayCommand(ExecuteExitCommand,CanExecuteExitCommand));
            }
        }
        #endregion

        #region private methods
        #endregion

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}