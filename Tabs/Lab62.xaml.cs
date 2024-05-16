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

namespace Labs.Tabs
{
    /// <summary>
    /// Interaction logic for Lab62.xaml
    /// </summary>
    public partial class Lab62 : UserControl, INotifyPropertyChanged
    {
        private int[] _numArray = new []{ 2, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private int _result;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Result 
        {
            get => _result;
            set
            {
                _result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }

        public string DisplayableArray => ArrayToString();

        public Lab62()
        {
            InitializeComponent();
            this.DataContext = this;
            CalculatePositiveSum();
        }

        private void CalculatePositiveSum()
        {
            Result = _numArray.ToList().Where(x=>x%2==0).Sum();
        }

        private string ArrayToString()
        {
            var sb = new StringBuilder();
            foreach (var item in _numArray)
            {
                sb.Append(item+" ");
            }
            return sb.ToString();
        }
    }
}
