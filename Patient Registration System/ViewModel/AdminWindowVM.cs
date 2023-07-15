using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Patient_Registration_System.ViewModel
{
    public class AdminWindowVM : BaseViewModel
    {
        private BaseViewModel _currentChildView;
        private string _caption;
        private IconChar _icon;

        public BaseViewModel CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                 _currentChildView = value; 
                OnPropetyChanged(nameof(CurrentChildView));
            } 
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropetyChanged(nameof(Icon));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropetyChanged(nameof(Caption));
            }
        }


   

        // Commands
        public ICommand ShowHomeViewCommand { get;}
        public ICommand ShowUsersViewCommand { get;}
        public ICommand ShowPatientsViewCommand { get;}
        public ICommand ShowDoctorsViewCommand { get;}
        public ICommand ShowTestsViewCommand { get;}
        public ICommand ShowOthersViewCommand { get;}

        // Constructor
        public AdminWindowVM() 
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowUsersViewCommand = new ViewModelCommand(ExecuteShowUsersViewCommand);
            ShowPatientsViewCommand = new ViewModelCommand(ExecuteShowPatientsViewCommand);
            ShowDoctorsViewCommand = new ViewModelCommand(ExecuteShowDoctorsViewCommand);
            ShowTestsViewCommand = new ViewModelCommand(ExecuteShowTestsViewCommand);
            ShowOthersViewCommand = new ViewModelCommand(ExecuteShowOthersViewCommand);



            //default view
           // ExecuteShowHomeViewCommand(null);

           
        }

        private void ExecuteShowOthersViewCommand(object obj)
        {
            CurrentChildView = new OthersWindowVM();
            Caption = "Others";
            Icon = IconChar.PeopleRoof;
        }

        private void ExecuteShowTestsViewCommand(object obj)
        {
            CurrentChildView = new TestsWindowVM();
            Caption = "Tests";
            Icon = IconChar.NotesMedical;
        }

        private void ExecuteShowDoctorsViewCommand(object obj)
        {
            CurrentChildView = new DoctorsWindowVM();
            Caption = "Doctors";
            Icon = IconChar.UserDoctor;
        }

        private void ExecuteShowPatientsViewCommand(object obj)
        {
            CurrentChildView = new PatientsWindowVM();
            Caption = "Patients";
            Icon = IconChar.Users;
        }

        private void ExecuteShowUsersViewCommand(object obj)
        {
            CurrentChildView = new UsersWindowVM();
            Caption = "Users";
            Icon = IconChar.UserPlus;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeWindowVM();
            Caption = "Dashboard";
            Icon = IconChar.Home;


        }
    }
}