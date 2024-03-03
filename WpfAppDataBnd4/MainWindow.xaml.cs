using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDataBnd4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Car myCar;
        public MainWindow()
        {
            InitializeComponent();

            myCar = new Car();

            //DataContext를 이용하면, xaml에서 binding시에 사용할 수 있다.
            //var myBingind = new Binding("Speed") { Source = myCar };
            //myText.SetBinding(TextBox.TextProperty, myBingind);
            this.DataContext = myCar;
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            myCar.Speed = 200;    //INotifyPropertyChanged 동작 확인을 위해.
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
    public class Car : Notifier
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
}