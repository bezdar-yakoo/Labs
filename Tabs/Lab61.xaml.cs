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
    /// Interaction logic for Lab61.xaml
    /// </summary>
    public partial class Lab61 : UserControl , INotifyPropertyChanged
    {
        private int _ivalue = 1;
        private int _jvalue = 3;
        private string _startText = "Some english text";

        public int IValue
        {
            get => _ivalue;
            set
            {
                _ivalue = value;
            }
        }

        public int JValue
        {
            get => _jvalue;
            set
            {
                _jvalue = value;
            }
        }

        public string Text
        {
            get => _startText;

            set
            {
                _startText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Lab61()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void ReplaceChars()
        {
            var replacedText = Text.ToCharArray();

            try
            {
                (replacedText[_ivalue], replacedText[_jvalue]) = (replacedText[_jvalue], replacedText[_ivalue]);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            Text = new string(replacedText);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var tt = App.FindVisualChildren<TextBox>(this);
                Keyboard.Focus(tt.FirstOrDefault(t => t != sender));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReplaceChars();
        }
    }
}
