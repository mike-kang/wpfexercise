using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDataBind3
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public Car myCar;
        public MainWindow()
        {
            InitializeComponent();

            myCar = new Car();
            var myBingind = new Binding("Speed"){Source = myCar};
            myText.SetBinding(TextBox.TextProperty, myBingind);
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            myCar.Speed = "200";    //INotifyPropertyChanged 동작 확인을 위해.
        }
    }
    public class Notifier/* : INotifyPropertyChanged*/
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
    public class Car : Notifier
    {
        private string _speed = "300";
        public string Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }
    }
}
