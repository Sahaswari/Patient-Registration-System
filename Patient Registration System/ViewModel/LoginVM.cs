using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Patient_Registration_System.Model;
using System.Windows;
using Patient_Registration_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.ViewModel
{
    public partial class LoginVM : ObservableObject
    {
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;


        [RelayCommand]
        public void Login()
        {
            using(DataContext context = new DataContext()) 
            {
                bool check = context.users.Any(User =>User.UserName == username && User.UserPassword==password);

                User user = context.users.FirstOrDefault(User => User.UserName == username && User.UserPassword == password);
                if(check)
                {
                    if (user.UserType == "admin")
                    {
                        var Window = new View.AdminWindow();
                        Window.Show();
                    }

                    else if(user.UserType == "normal")
                    {
                       var Window = new View.MainWindow();
                       Window.Show();
                    }
                }
                else
                {
                    MessageBox.Show("User not Found! Recheck and Enter.");
                }
            }




        }

    }
}
