using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBind6.ViewModels
{
    public class ScreenViewModel : Notifier
    {
        private int _speed = 300;
        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }
    }

    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
