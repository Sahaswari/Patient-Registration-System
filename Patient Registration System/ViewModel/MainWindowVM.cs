using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Input;


namespace Patient_Registration_System.ViewModel
{
    public class MainWindowVM : BaseViewModel
    {
        private BaseViewModel _nCurrentChildView;
        private string _nCaption;
        private IconChar _nIcon;


        public BaseViewModel NCurrentChildView
        {
            get
            {
                return _nCurrentChildView;
            }

            set
            {
                _nCurrentChildView = value;
                OnPropetyChanged(nameof(NCurrentChildView));
            }
        }

        public IconChar NIcon
        {
            get
            {
                return _nIcon;
            }

            set
            {
                _nIcon = value;
                OnPropetyChanged(nameof(NIcon));
            }
        }

        public string NCaption
        {
            get
            {
                return _nCaption;
            }

            set
            {
                _nCaption = value;
                OnPropetyChanged(nameof(NCaption));
            }
        }


        public ICommand ShowNHomeViewCommand { get; }
        public ICommand ShowNRegistrationViewCommand { get; }
        public ICommand ShowNUpdateViewCommand { get; }
        public ICommand ShowNDeleteViewCommand { get; }
        public ICommand ShowNPayementsViewCommand { get; }

        public MainWindowVM()
        {
            ShowNHomeViewCommand = new ViewModelCommand(ExecuteShowNHomeViewCommand);
            ShowNRegistrationViewCommand = new ViewModelCommand(ExecuteShowNRegistrationViewCommand);
            ShowNUpdateViewCommand = new ViewModelCommand(ExecuteShowNUpdateViewCommand);
            ShowNDeleteViewCommand = new ViewModelCommand(ExecuteShowNDeleteViewCommand);
            ShowNPayementsViewCommand = new ViewModelCommand(ExecuteShowNPayementsViewCommand);


            ExecuteShowNHomeViewCommand(null);

        }

        private void ExecuteShowNPayementsViewCommand(object obj)
        {
            NCurrentChildView = new NPayementsWindowVM();
            NCaption = "Payements";
            NIcon = IconChar.MoneyCheckDollar;
        }

        private void ExecuteShowNDeleteViewCommand(object obj)
        {
            NCurrentChildView = new NDeleteWindowVM();
            NCaption = "Delete";
            NIcon = IconChar.Trash;
        }

        private void ExecuteShowNUpdateViewCommand(object obj)
        {
            NCurrentChildView = new NUpdateWindowVM();
            NCaption = "Update";
            NIcon = IconChar.Upload;
        }

        private void ExecuteShowNRegistrationViewCommand(object obj)
        {
            NCurrentChildView = new NRegistrationWindowVM();
            NCaption = "Registration";
            NIcon = IconChar.UserPlus;
        }

        private void ExecuteShowNHomeViewCommand(object obj)
        {
            NCurrentChildView = new NHomeWindowVM();
            NCaption = "Home";
            NIcon = IconChar.Home;
        }
    }
}
