using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Airport.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        //Логин
        public string Login;
        private string login 
        { get
            { 
                return Login; 
            }
            set 
            {
                Login = value;
                OnPropertyChanged();
            }
        }


        //Реальизация интерфейся
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
