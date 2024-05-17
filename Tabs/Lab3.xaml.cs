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
    public partial class Lab3 : UserControl, INotifyPropertyChanged
    {
        public double XValue
        {
            get => _xValue; set
            {
                _xValue = value;
                CalculateP();
            }
        }
        public double YValue
        {
            get => _yValue; set
            {
                _yValue = value;
                CalculateP();
            }
        }
        public double ZValue
        {
            get => _zValue; set
            {
                _zValue = value;
                CalculateP();
            }
        }


        public double PValue
        {
            get => _pValue; set
            {
                _pValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("YValue"));
            }
        }

        private double _pValue,
            _xValue = 10,
            _yValue = 10,
            _zValue = 10;



        public event PropertyChangedEventHandler? PropertyChanged;


        public Lab3()
        {
            InitializeComponent();
            this.DataContext = this;
            CalculateP();
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var tt = App.FindVisualChildren<TextBox>(this);
                Keyboard.Focus(tt.FirstOrDefault(t => t != sender));
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CalculateP();
        }

        private double GetXFunction()
        {

            var radioButtons = App.FindVisualChildren<RadioButton>(radioButtonsGroup);
            var function = radioButtons.First(t => t.IsChecked == true).Content.ToString();

            switch (function)
            {
                case "Sin(x)": 
                    return Math.Sin(XValue);
                case "Cos(x)": 
                    return Math.Cos(XValue);
                case "Tan(x)": 
                    return Math.Tan(XValue);
                default:
                    return XValue;
            }
            
        }

        private void CalculateP()
        {
            PValue = Math.Abs(Math.Min(GetXFunction(), YValue) - Math.Max(YValue, ZValue)) / 2;
            Debug.WriteLine($"X0Value: {XValue}\nYValue: {YValue}\nZValue: {ZValue}\nFValue: {PValue}\n");
        }


    }
}
