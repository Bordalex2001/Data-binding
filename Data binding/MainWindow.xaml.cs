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

namespace Data_binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private double number_a;
        private double number_b;
        private double result;

        public double Number_a
        {
            get { return number_a; }
            set
            {
                if (number_a != value)
                {
                    number_a = value;
                    OnPropertyChanged(nameof(Number_a));
                    CalculateResult();
                }
            }
        }

        public double Number_b
        {
            get { return number_b; }
            set
            {
                if (number_b != value)
                {
                    number_b = value;
                    OnPropertyChanged(nameof(Number_b));
                    CalculateResult();
                }
            }
        }

        public double Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateResult()
        {
            Result = Number_a + Number_b;
        }
    }
    
    public partial class MainWindow : Window
    {
        public ViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ViewModel();
            DataContext = ViewModel;
        }
    }
}