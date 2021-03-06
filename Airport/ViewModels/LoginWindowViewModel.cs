﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Airport.RelayCommands;
using Airport.SQLExecute;


namespace Airport.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        //Логин
        private string login="";
        public string Login 
        { get
            { 
                return login; 
            }
            set 
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        private string password;

        //Команда входа
        private RelayCommand enterCommand;
        public RelayCommand EnterCommand
        {
            get
            {
                return enterCommand ??
                  (enterCommand = new RelayCommand(obj =>
                  {
                      password = obj as string;
                      login = password;
                      SqlCommands sqlCommands = new SqlCommands();
                      SqlCommands.Server = "";//Добавить сервер
                      SqlCommands.Port = 3306;//Добавить порт
                      SqlCommands.Id = "";//Добавить id
                      SqlCommands.Password = "";//Добавить пароль
                      string querry = "select * from userLogin where (iduserLogin = @Param1 && password= @Param2)";

                  }, (obj) => login.Length>0));
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
