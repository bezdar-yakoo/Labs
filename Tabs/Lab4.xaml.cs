using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Labs.Tabs
{
    /// <summary>
    /// Логика взаимодействия для Lab4.xaml
    /// </summary>
    public partial class Lab4 : UserControl, INotifyPropertyChanged
    {

        public double X0Value
        {
            get => _x0Value; set
            {
                _x0Value = value;
                CalculateY();
            }
        }
        public double XKValue
        {
            get => _xKValue; set
            {
                _xKValue = value;
                CalculateY();
            }
        }
        public double DXValue
        {
            get => _dXValue; set
            {
                _dXValue = value;
                CalculateY();
            }
        }
        public double BValue
        {
            get => _bValue; set
            {
                _dXValue = value;
                CalculateY();
            }
        }


        public string YValue
        {
            get => _yValue; set
            {
                _yValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("YValue"));
            }
        }

        private double
            _x0Value = -0.73,
            _xKValue = -1.73,
            _dXValue = -0.1,
            _bValue = -2;

        private string _yValue;


        public event PropertyChangedEventHandler? PropertyChanged;

        public Lab4()
        {
            InitializeComponent();
            this.DataContext = this;
            CalculateY();
        }

        private void CalculateY()
        {
            List<string> value = new List<string>();
            value.Add( "Работу выполнила Серегина Ангелина");

            for (double x = X0Value; x > XKValue; x += DXValue)
            {
                double res = Math.Pow(Math.Abs(x - BValue), 0.5) / Math.Pow(Math.Abs(Math.Pow(BValue, 3) - Math.Pow(x, 3)), 3 / 2) + Math.Log(Math.Abs(x - BValue));
                value.Add($"При X = {Math.Round(x, 2)}, ответ = {res}");
            }

            YValue = string.Join("\n", value);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var tt = App.FindVisualChildren<TextBox>(this);
                Keyboard.Focus(tt.FirstOrDefault(t => t != sender));
            }
        }
    }
}
