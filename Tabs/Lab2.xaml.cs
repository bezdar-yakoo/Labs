using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;

namespace Labs.Tabs
{
    /// <summary>
    /// Логика взаимодействия для Lab2.xaml
    /// </summary>
    public partial class Lab2 : UserControl, INotifyPropertyChanged
    {
        public double XValue
        {
            get => _xValue; set
            {
                _xValue = value;
                CalculateF();
            }
        }
        public double YValue
        {
            get => _yValue; set
            {
                _yValue = value;
                CalculateF();
            }
        }
        public double ZValue
        {
            get => _zValue; set
            {
                _zValue = value;
                CalculateF();
            }
        }


        public double FValue
        {
            get => _fValue; set
            {
                _fValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("YValue"));
            }
        }

        private double _fValue,
            _xValue = 17.421,
            _yValue = 0.010365,
            _zValue = 82800;

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var tt = App.FindVisualChildren<TextBox>(this);
                Keyboard.Focus(tt.FirstOrDefault(t => t != sender));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public Lab2()
        {
            InitializeComponent();
            this.DataContext = this;
            CalculateF();
        }

        private void CalculateF()
        {
            FValue =  (Math.Pow((YValue + Math.Pow(XValue - 1, 1 / 3)), 1 / 4)) /  (Math.Abs(XValue - YValue) * (Math.Pow(Math.Sin(ZValue), 2) + Math.Tan(ZValue)));
            Debug.WriteLine($"X0Value: {XValue}\nYValue: {YValue}\nZValue: {ZValue}\nFValue: {FValue}\n");
        }


    }
}
