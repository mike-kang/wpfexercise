using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDataBind4_thread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Car myCar;
        TextBox myText = new TextBox();

        public MainWindow()
        {
            InitializeComponent();

            myPannel.Children.Add(myText);
            myCar = new Car();
            var myBingind = new Binding("Speed") { Source = myCar };
            myText.SetBinding(TextBox.TextProperty, myBingind);
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(1000);
                    myCar.Speed = 20 * i;
                }
            }).Start();
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